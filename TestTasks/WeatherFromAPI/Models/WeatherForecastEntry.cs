using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestTasks.WeatherFromAPI.Models;

[DataContract]
public class WeatherForecastEntry
{
    [DataMember(Name = "dt")]
    public long DateTimeUnix { get; set; }

    [DataMember(Name = "main")]
    public MainWeatherData Temperature { get; set; }

    [DataMember(Name = "weather")]
    public List<WeatherCondition> Weather { get; set; }

    [DataMember(Name = "clouds")]
    public CloudsData Clouds { get; set; }

    [DataMember(Name = "wind")]
    public WindData Wind { get; set; }

    [DataMember(Name = "visibility")]
    public int Visibility { get; set; }

    [DataMember(Name = "pop")]
    public double ProbabilityOfPrecipitation { get; set; }

    [DataMember(Name = "rain")]
    public RainData Rain { get; set; }

    [DataMember(Name = "snow")]
    public SnowData Snow { get; set; }

    [DataMember(Name = "dt_txt")]
    public string DateTimeText { get; set; }
}