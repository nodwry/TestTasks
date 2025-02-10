using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class WeatherCondition
{
    [DataMember(Name = "id")]
    public int Id { get; set; }

    [DataMember(Name = "main")]
    public string Main { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "icon")]
    public string Icon { get; set; }
}