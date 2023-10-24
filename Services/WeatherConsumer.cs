using Microsoft.Extensions.Logging;
using OpenMeteo;
using Steeltoe.Messaging.Handler.Attributes;
using Steeltoe.Messaging.RabbitMQ.Attributes;
using Steeltoe.Stream.Attributes;
using Steeltoe.Stream.Messaging;
using WeatherWebServer.Model;


namespace WeatherWebServer.Services
{
    [EnableBinding(typeof(ISink))]
    public class WeatherConsumer
    {
        private ILogger<WeatherConsumer> _logger;

        public WeatherConsumer(ILogger<WeatherConsumer> logger)
        {
            _logger = logger;
        }

        [StreamListener(ISink.INPUT)]
        //[SendTo(ISink.INPUT)]
        //[DeclareQueueBinding(Name = "weather", QueueName = "weather")]
        public void Handle(string strForecast)
        {
            var forecast = System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(strForecast);
            _logger.LogInformation("Received forecast for: " + forecast.Name);
            //return forecast;
        }
    }
}