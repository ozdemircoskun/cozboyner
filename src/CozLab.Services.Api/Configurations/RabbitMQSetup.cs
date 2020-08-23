using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.ObjectPool;  
using RabbitMQ.Client;
using CozLab.Domain.Core.RabbitMQSettings;
using CozLab.Domain.RabbitMQInterfaces;
using CozLab.Domain.RabbitMQ;
using CozLab.Infra.Data.RabbitMQManager;

namespace CozLab.Services.Api.Configurations
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

 
