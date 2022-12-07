using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduceController : ControllerBase
    {
        private Action<DeliveryReport<Null, string>> cancellationToken;

        [HttpGet]
        public List<string> GetProducedMessages(/*[FromBody] string message*/)
        {
            List<string> msgs = new List<string>();
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
                EnableIdempotence = true // This will make sure the messages are senting in the right order

            };

            IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();

            foreach (string value in JsonUtils.GetListOfMessagesFromFile())
            {
                //string value = message;
                producer.Produce("LSports", new Message<Null, string> { Value = value }, cancellationToken);
                msgs.Add($"Produce message '{value}");
                Console.WriteLine($"Produce message '{value}");

            }
            producer.Flush(TimeSpan.FromSeconds(10));

            return msgs;
        }
    }
}

