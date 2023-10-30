using Microsoft.Extensions.Logging;
using OpenMeteo;
using Steeltoe.Stream.Attributes;
using Steeltoe.Stream.Messaging;


namespace WeatherWebServer.Services
{
    [EnableBinding(typeof(ISink))]
    public class WeatherConsumer
    {
        private ILogger<WeatherConsumer> _logger;
        private readonly WeatherRepository _weatherRepository;

        public WeatherConsumer(ILogger<WeatherConsumer> logger, WeatherRepository weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [StreamListener(ISink.INPUT)]
        //[SendTo(ISink.INPUT)]
        //[DeclareQueueBinding(Name = "weather", QueueName = "weather")]
        public void Handle(string strForecast)
        {
            var forecast = System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(strForecast);
            _logger.LogInformation("Received forecast for: " + forecast.Name);
            _weatherRepository.Save(forecast.Name, forecast);
        }
    }
}