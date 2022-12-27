using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebAPI.Domain.Models;

namespace WebAPI.Application.UserCases.OrderUserCase
{
    public class OrderUserCase : IOrderUserCase
    {
        private ILogger<OrderUserCase> _logger;

        public OrderUserCase(ILogger<OrderUserCase> logger)
        {
            _logger = logger;
        }

        public async Task<Order> InsertOrder(Order order)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "orderQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = JsonSerializer.Serialize(order);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "orderQueue",
                                         basicProperties: null,
                                         body: body);
                }
                return order;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error trying to create a new order", ex);
                throw new Exception();
            }
        }
    }
}
