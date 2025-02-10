using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class CloudsData
{
    [DataMember(Name = "all")]
    public int Cloudiness { get; set; }
}