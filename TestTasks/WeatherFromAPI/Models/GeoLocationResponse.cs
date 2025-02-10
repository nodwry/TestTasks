using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class GeoLocationResponse
{
    [DataMember(Name = "lat")]
    public double Latitude { get; set; }

    [DataMember(Name = "lon")]
    public double Longitude { get; set; }
}