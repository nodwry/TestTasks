namespace TestTasks.WeatherFromAPI.Models;

public class WeatherComparisonResult(string cityA, string cityB, int warmerDays, int rainierDays)
{
    public string CityA { get; init; } = cityA;

    public string CityB { get; init; } = cityB;

    public int WarmerDaysCount { get; init; } = warmerDays;

    public int RainierDaysCount { get; init; } = rainierDays;
}