using CozLab.RabbitMQ.Consumer.Configurations;
using CozLab.RabbitMQ.Consumer.ReadoutConsumers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CozLab.RabbitMQ.Consumer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<HostOptions>().Configure(
                opts => opts.ShutdownTimeout = TimeSpan.FromSeconds(60));


            services.AddRabbitMQSetup(Configuration);

            //Mongo Env

            services.AddMongoSetup(Configuration);

 

            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            services.AddAutoMapperSetup();

            

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



            // .NET Native DI Abstraction
            services.AddDependencyInjectionSetup();

            services.AddHostedService<WorkerManagerService>();


             
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
              

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }



    }
}
