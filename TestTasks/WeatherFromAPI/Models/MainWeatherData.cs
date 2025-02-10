using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class MainWeatherData
{
    [DataMember(Name = "temp")]
    public double Temperature { get; set; }

    [DataMember(Name = "feels_like")]
    public double FeelsLike { get; set; }

    [DataMember(Name = "temp_min")]
    public double MinTemperature { get; set; }

    [DataMember(Name = "temp_max")]
    public double MaxTemperature { get; set; }

    [DataMember(Name = "pressure")]
    public int Pressure { get; set; }

    [DataMember(Name = "humidity")]
    public int Humidity { get; set; }
}