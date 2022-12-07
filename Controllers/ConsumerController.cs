using Confluent.Kafka;
using Kafka.Public;
using Kafka.Public.Loggers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        static readonly CancellationTokenSource cancelToken = new CancellationTokenSource();


        private List<string> LoopProcedure(CancellationToken token)
        {
            List<string> msgs = new List<string>();

            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers",
                BootstrapServers = "localhost:9092"
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("LSports");
                while (true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine(cr.Message.Value);
                    msgs.Add(cr.Message.Value);

                    if (token.IsCancellationRequested)
                    {
                        return msgs;
                    }
                }
            }

            return msgs;


        }

        [HttpPost("timeInSeconds")]
        public List<string> GetConsumedMessages([FromBody] int timeInSeconds)
        {

            cancelToken.CancelAfter(1000 * timeInSeconds);

            var task = Task.Run(() => LoopProcedure(cancelToken.Token));
            task.Wait(timeInSeconds * 1000);
            return task.Result;
        }
    }

}
