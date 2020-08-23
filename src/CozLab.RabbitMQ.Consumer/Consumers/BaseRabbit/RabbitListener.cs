
using CozLab.Domain.Core.RabbitMQSettings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;


namespace CozLab.RabbitMQ.Consumer
{
    public class RabbitListener
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private bool IsClose = false;
        public RabbitListener(IOptions<RabbitOptions> options)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = options.Value.HostName,
                    UserName = options.Value.UserName,
                    Password = options.Value.Password,
                    Port = options.Value.Port,
                };
                this.connection = factory.CreateConnection();
                this.channel = connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RabbitListener init error,ex:{ex.Message}");
            }
        }

        public string RouteKey;
        public string QueueName;
        public string ExchangeName;

        public string WorkerGuid;
       
        public virtual bool Process(string message)
        {
            throw new NotImplementedException();
        }


        public void PreDeRegister()
        {
            IsClose = true;
        }

        private void DeRegister()
        {
            this.connection.Close();
            this.channel.Close();
        }
        public void Register()
        {
            Console.WriteLine($"RabbitListener register,routeKey:{RouteKey}");

            channel.QueueBind(queue: QueueName,
                              exchange: ExchangeName,
                              routingKey: RouteKey);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                if (IsClose)
                {
                    channel.BasicReject(ea.DeliveryTag, true);
                    DeRegister();
                }
                else
                {
                    var body = ea.Body;
                    var message = System.Text.Encoding.UTF8.GetString(body.Span);
                    var result = Process(message);
                    if (result)
                    {
                        channel.BasicAck(ea.DeliveryTag, false);
                    }

                }


            };
            channel.BasicConsume(queue: QueueName, consumer: consumer);
        }

    }

}
