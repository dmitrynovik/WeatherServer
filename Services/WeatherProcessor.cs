using Microsoft.Extensions.Logging;
using Steeltoe.Messaging.Handler.Attributes;
using Steeltoe.Messaging.RabbitMQ.Attributes;
using Steeltoe.Stream.Attributes;
using Steeltoe.Stream.Messaging;
using WeatherServer.Model;


namespace Basic
{
    [EnableBinding(typeof(ISink))]
    public class WeatherProcessor
    {
        private ILogger<WeatherProcessor> _logger;

        public WeatherProcessor(ILogger<WeatherProcessor> logger)
        {
            _logger = logger;
        }

        //[StreamListener(IProcessor.INPUT)]
        //[SendTo(ISink.INPUT)]
        [DeclareQueueBinding(Name = "weather", QueueName = "weather")]
        public Coordinate Handle(Coordinate input)
        {
            return input;
        }
    }
}