using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class SnowData
{
    [DataMember(Name = "3h")]
    public double Last3Hours { get; set; }
}