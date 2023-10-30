using System.Collections.Concurrent;
using System.Collections.Generic;
using OpenMeteo;

namespace WeatherWebServer.Services {
    public class WeatherRepository {
        private IDictionary<string, WeatherForecast> _forecasts = new ConcurrentDictionary<string, WeatherForecast>();

        public void Save(string location, WeatherForecast forecast) => _forecasts[location] = forecast;

        public WeatherForecast Get(string location) => _forecasts.TryGetValue(location, out WeatherForecast val) ? val : null;
    }   
}

