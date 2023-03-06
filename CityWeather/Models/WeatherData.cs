using System.Text.Json.Serialization;

namespace WeatherAPI.Model
{
    public class WeatherData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("main")]
        public TemperatureData TemperatureData { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDescription> WeatherDescriptions { get; set; }
    }
}
