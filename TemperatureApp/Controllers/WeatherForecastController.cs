using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureApp.Models;
using TemperatureApp.Services;

namespace TemperatureApp.Controllers
{
    // Controllers/WeatherForecastController.cs
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherForecastController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{location}")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(string location)
        {
            return await _weatherService.GetWeatherForecasts(location);
        }
    }

}
