using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class CityInfo
{
    [DataMember(Name = "id")]
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "coord")]
    public GeoLocationResponse Coordinates { get; set; }

    [DataMember(Name = "country")]
    public string Country { get; set; }
}