using CityWeather.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherAPI.Model;

namespace CityWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public static string message;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string input)
        {
            var output = new ModelMessage { Message =input};
            message= output.Message;

            // Return the output to the view
            return View(output);
        }

        public async Task<IActionResult> Weather()
        {
            var client = _httpClientFactory.CreateClient();
            var city = message;
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q="+city+"&appid=e7704bc895b4a8d2dfd4a29d404285b6&units=metric";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }

            string json = await response.Content.ReadAsStringAsync();
            WeatherData data = JsonSerializer.Deserialize<WeatherData>(json);

            var weatherInfo = new Weather
            {
                City = data.Name,
                Temperature = data.TemperatureData.Temperature,
                Description = data.WeatherDescriptions[0].Description
            };

            return View(weatherInfo);
        }
    }
}
