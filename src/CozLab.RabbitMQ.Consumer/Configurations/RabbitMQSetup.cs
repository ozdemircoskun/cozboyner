using CozLab.Domain.Core.RabbitMQSettings;
using CozLab.Domain.RabbitMQ;
using CozLab.Domain.RabbitMQInterfaces;
using CozLab.Infra.Data.RabbitMQManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace CozLab.RabbitMQ.Consumer.Configurations
{
    public static class RabbitMQSetup
    {
        public static void AddRabbitMQSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitConfig = configuration.GetSection("rabbit");
            services.Configure<RabbitOptions>(rabbitConfig);

            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModelPooledObjectPolicy>();

            services.AddSingleton<IRabbitManager, RabbitManager>();
        }
    }
}


