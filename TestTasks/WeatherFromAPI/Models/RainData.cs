using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class RainData
{
    [DataMember(Name = "3h")]
    public double Last3Hours { get; set; }
}