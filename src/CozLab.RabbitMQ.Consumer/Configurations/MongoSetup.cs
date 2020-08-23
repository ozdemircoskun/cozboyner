using CozLab.Domain.Core.MongoSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CozLab.RabbitMQ.Consumer.Configurations
{
    public static class MongoSetup
    {
        public static void AddMongoSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("MongoDbSettings");
            services.Configure<MongoDbSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<MongoDbSettings>();

            services.AddSingleton<IMongoDbSettings>(appSettings);
        }
    }
}