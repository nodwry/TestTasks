using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class WeatherApiResponse
{
    [DataMember(Name = "cod")]
    public string StatusCode { get; set; }

    [DataMember(Name = "message")]
    public int Message { get; set; }

    [DataMember(Name = "cnt")]
    public int Count { get; set; }

    [DataMember(Name = "list")]
    public List<WeatherForecastEntry> Forecasts { get; set; }

    [DataMember(Name = "city")]
    public CityInfo City { get; set; }
}