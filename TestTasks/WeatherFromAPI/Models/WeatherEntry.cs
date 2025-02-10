using System;
using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class WeatherEntry
{
    [DataMember]
    public DateTime Date { get; set; }

    [DataMember]
    public double Temperature { get; set; }

    [DataMember]
    public double RainVolume { get; set; }
}