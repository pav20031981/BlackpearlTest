using TemperatureApp.Models;

namespace TemperatureApp.Services
{
    // Services/WeatherService.cs
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(string location)
        {
            string apiKey = _configuration["TomorrowIoApiKey"];
            string apiUrl = $"https://api.tomorrow.io/v4/timelines?location={location}&fields=temperature_2m&apikey={apiKey}";

            var response = await _httpClient.GetFromJsonAsync<WeatherApiResponse>(apiUrl);

            return response?.Data?.Timelines?.Select(timeline => new WeatherForecast
            {
                Date = timeline.StartDateTime.Date,
                Location = location,
                TemperatureCelsius = timeline.Temperature2m
            });
        }
    }

}