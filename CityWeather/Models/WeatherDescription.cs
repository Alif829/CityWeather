using System.Text.Json.Serialization;

namespace WeatherAPI.Model
{
    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
