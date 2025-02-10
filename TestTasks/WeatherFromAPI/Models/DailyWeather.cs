using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class DailyWeather
{
    [DataMember]
    public double AvgTemp { get; set; }

    [DataMember]
    public double TotalRain { get; set; }
}