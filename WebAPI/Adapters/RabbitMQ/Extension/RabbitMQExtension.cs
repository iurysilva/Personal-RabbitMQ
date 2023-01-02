using Adapters.RabbitMQ.Models.Settings;
using WebAPI.Adapters.RabbitMQ.Services;

namespace Adapters.RabbitMQ.Extension
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQAdapter(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Fabrica.json")
                .Build();

            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQ"));
            services.AddSingleton<IRabbitMQService, RabbitMQService>();

            return services;
        }
    }
}
