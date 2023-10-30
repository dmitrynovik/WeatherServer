using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenMeteo;
using WeatherWebServer.Services;

namespace WeatherWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherRepository _weatherRepository;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger, WeatherRepository weatherRepository)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public async Task<WeatherForecast> Get(double lat = -33.52, double lon = 151.12)
        {   
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,windspeed_10m&hourly=temperature_2m,relativehumidity_2m,windspeed_10m";
            _logger.LogInformation("Getting forecast");

            using var client = _httpClientFactory.CreateClient();        
            var response = await client.GetFromJsonAsync<WeatherForecast>(url);
            return response;
        }

        public WeatherForecast Get2(string location) => _weatherRepository.Get(location);
    }
}
