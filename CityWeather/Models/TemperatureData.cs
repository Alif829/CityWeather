using System.Text.Json.Serialization;

namespace WeatherAPI.Model
{
    public class TemperatureData
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
    }
}
