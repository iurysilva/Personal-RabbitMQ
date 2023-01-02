using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebAPI.Adapters.RabbitMQ.Services;
using WebAPI.Domain.Models;

namespace WebAPI.Application.UserCases.OrderUserCase
{
    public class OrderUserCase : IOrderUserCase
    {
        private ILogger<OrderUserCase> _logger;
        protected IRabbitMQService _rabbitService;
        public OrderUserCase(ILogger<OrderUserCase> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _rabbitService = (IRabbitMQService)serviceProvider.GetRequiredService(typeof(IRabbitMQService));
        }

        public async Task<bool> InsertOrder(Order order)
        {
            try
            {
                //var factory = new ConnectionFactory() { 
                //    HostName = "192.168.0.63",
                //    UserName = "automacao",
                //    Password= "automacao123",
                //    Port = 5672
                //};
                //using (var connection = factory.CreateConnection())
                //using (var channel = connection.CreateModel())
                //{
                //    channel.QueueDeclare(queue: "testing_order_Queue",
                //                         durable: false,
                //                         exclusive: false,
                //                         autoDelete: false,
                //                         arguments: null);

                //    string message = JsonSerializer.Serialize(order);
                //    var body = Encoding.UTF8.GetBytes(message);

                //    channel.BasicPublish(exchange: "",
                //                         routingKey: "testing_order_Queue",
                //                         basicProperties: null,
                //                         body: body);
                //}
                //return order;
                return await _rabbitService.PublishMessage(order, "testing_order_Queue");

            }
            catch(Exception ex)
            {
                _logger.LogError("Error trying to create a new order", ex);
                throw new Exception();
            }
        }
    }
}
