namespace Adapters.RabbitMQ.Models.Settings
{
    public record RabbitMQSettings
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public string? Host { get; set; }
    }
}
