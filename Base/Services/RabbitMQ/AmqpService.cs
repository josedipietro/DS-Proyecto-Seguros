using System;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Base.Services.RabbitMQ
{
    public class AmqpService
    {
        private readonly AmqpInfo amqpInfo;
        private readonly ConnectionFactory connectionFactory;

        public AmqpService(IOptions<AmqpInfo> ampOptionsSnapshot)
        {
            amqpInfo = ampOptionsSnapshot.Value;

            connectionFactory = new ConnectionFactory
            {
                UserName = amqpInfo.Username,
                Password = amqpInfo.Password,
                VirtualHost = amqpInfo.VirtualHost,
                HostName = amqpInfo.HostName,
                Uri = new Uri(amqpInfo.Uri)
            };
        }

        public void PublishMessage(object message, string QueueName)
        {
            using (var conn = connectionFactory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    // Verify if the queue exists (if not, create it)
                    channel.QueueDeclare(QueueName, false, false, false, null);

                    var jsonPayload = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonPayload);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: QueueName,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }

        public async Task SendMessageAsync<T>(T message, string QueueName)
        {
            await Task.Run(() =>
            {
                using (var conn = connectionFactory.CreateConnection())
                {
                    using (var channel = conn.CreateModel())
                    {
                        channel.QueueDeclare(
                            queue: QueueName,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                        );

                        var jsonPayload = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(jsonPayload);

                        channel.BasicPublish(
                            exchange: "",
                            routingKey: QueueName,
                            basicProperties: null,
                            body: body
                        );
                    }
                }
            });
        }

        // Send message asyn
    }
}
