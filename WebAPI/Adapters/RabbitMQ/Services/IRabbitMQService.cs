namespace WebAPI.Adapters.RabbitMQ.Services
{
    public interface IRabbitMQService
    {
        Task<bool> PublishMessage<T>(T message, string topic);
    }
}
