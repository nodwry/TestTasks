using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TestTasks.WeatherFromAPI.Models;

namespace TestTasks.WeatherFromAPI;

public class WeatherManager
{
    private const string ApiKey = "0a83f5e37b9e8562e58ef23f6c0f56db"; 
    private const string GeocodingApiUrl = "http://api.openweathermap.org/geo/1.0/direct";
    private const string ForecastApiUrl = "https://api.openweathermap.org/data/2.5/forecast";

    private readonly HttpClient _httpClient = new();

    public async Task<WeatherComparisonResult> CompareWeather(string cityA, string cityB, int dayCount)
    {
        if (dayCount is < 1 or > 5)
            throw new ArgumentException("Number of days must be between 1 and 5.");
            
        var coordsA = await GetCityCoordinates(cityA);
        var coordsB = await GetCityCoordinates(cityB);
            
        var weatherA = await GetWeatherData(coordsA.Latitude, coordsA.Longitude);
        var weatherB = await GetWeatherData(coordsB.Latitude, coordsB.Longitude);
            
        int warmerDays = 0, rainierDays = 0;
        var groupedWeatherA = GroupWeatherByDay(weatherA);
        var groupedWeatherB = GroupWeatherByDay(weatherB);

        for (var i = 0; i < dayCount; i++)
        {
            var dayA = groupedWeatherA.ElementAtOrDefault(i);
            var dayB = groupedWeatherB.ElementAtOrDefault(i);

            if (dayA.Value.AvgTemp > dayB.Value.AvgTemp)
                warmerDays++;
            if (dayA.Value.TotalRain > dayB.Value.TotalRain)
                rainierDays++;
        }

        return new WeatherComparisonResult(cityA, cityB, warmerDays, rainierDays);
    }

    private async Task<GeoLocationResponse> GetCityCoordinates(string cityName)
    {
        var url = $"{GeocodingApiUrl}?q={cityName}&limit=1&appid={ApiKey}";
        var response = await _httpClient.GetStringAsync(url);
        var geoData = DeserializeJson<List<GeoLocationResponse>>(response);

        if (geoData == null || geoData.Count == 0)
            throw new ArgumentException($"City '{cityName}' not found.");

        return geoData[0];
    }

    private async Task<List<WeatherEntry>> GetWeatherData(double lat, double lon)
    {
        var url = $"{ForecastApiUrl}?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";
        var response = await _httpClient.GetStringAsync(url);
        var weatherData = DeserializeJson<WeatherApiResponse>(response);

        if (weatherData?.Forecasts == null)
            throw new Exception("Failed to fetch weather data.");

        return weatherData.Forecasts.Select(entry => new WeatherEntry
        {
            Date = DateTime.Parse(entry.DateTimeText).Date,
            Temperature = entry.Temperature.Temperature,
            RainVolume = entry.Rain?.Last3Hours ?? 0
        }).ToList();
    }

    private Dictionary<DateTime, DailyWeather> GroupWeatherByDay(List<WeatherEntry> weatherEntries)
    {
        return weatherEntries.GroupBy(w => w.Date)
            .ToDictionary(
                g => g.Key,
                g => new DailyWeather
                {
                    AvgTemp = g.Average(e => e.Temperature),
                    TotalRain = g.Sum(e => e.RainVolume)
                }
            );
    }

    private static T DeserializeJson<T>(string json)
    {
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var serializer = new DataContractJsonSerializer(typeof(T));
        return (T)serializer.ReadObject(ms);
    }
}