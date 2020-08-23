using System;
using AutoMapper;
using CozLab.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CozLab.Domain.Core.MongoSettings;

namespace CozLab.Services.Api.Configurations
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