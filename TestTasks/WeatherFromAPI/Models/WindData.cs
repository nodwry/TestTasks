using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class WindData
{
    [DataMember(Name = "speed")]
    public double Speed { get; set; }

    [DataMember(Name = "deg")]
    public int Degree { get; set; }

    [DataMember(Name = "gust")]
    public double Gust { get; set; }
}