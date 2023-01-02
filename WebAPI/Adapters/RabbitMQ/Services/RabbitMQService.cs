using Adapters.RabbitMQ.Models.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace WebAPI.Adapters.RabbitMQ.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        IOptions<RabbitMQSettings> _settings;
        public RabbitMQService(IOptions<RabbitMQSettings> settings)
        {
            this._settings = settings;
        }

        public async Task<bool> PublishMessage<T>(T message, string messageQueue)
        {
                try
                {
                    var factory = new ConnectionFactory() { 
                        HostName = _settings.Value.Host,
                        Port = _settings.Value.Port,
                        Password= _settings.Value.Password,
                        UserName= _settings.Value.UserName,
                        
                    };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: messageQueue,
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        string body = JsonSerializer.Serialize(message);
                        var encodedBody = Encoding.UTF8.GetBytes(body);

                        channel.BasicPublish(exchange: "",
                                             routingKey: messageQueue,
                                             basicProperties: null,
                                             body: encodedBody);
                    }
                    return true;
                }
                catch { throw; };
        }
    }
}
