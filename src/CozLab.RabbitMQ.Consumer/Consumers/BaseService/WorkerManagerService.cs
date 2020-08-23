using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.RabbitMQSettings;
using CozLab.Domain.RabbitMQInterfaces;
using CozLab.RabbitMQ.Consumer.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CozLab.RabbitMQ.Consumer.ReadoutConsumers
{

    public class WorkerManagerService :  BgService
    { 
        private readonly IServiceProvider _services;
        private readonly ILogger<WorkerManagerService> _logger;
        private readonly IOptions<RabbitOptions> _options;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public WorkerManagerService(ILogger<WorkerManagerService> logger, IServiceProvider services, IOptions<RabbitOptions> options, Microsoft.Extensions.Configuration.IConfiguration configuration )
        {
            _logger = logger;
            _services = services;
            _options = options;
            _configuration = configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"WorkerManagerService is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($"WorkerManagerService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                InitConsumer();
                await Task.Delay(10000, stoppingToken);
            }

            _logger.LogDebug($"WorkerManagerService background task is stopping.");
        }
        private void InitConsumer()
        {
            //var appSettingsSection = _configuration.GetSection("AppSettings"); 
            //var appSettings = appSettingsSection.Get<AppSettings>();
            try
            {
                DemoQueue1Consumer cmd = new DemoQueue1Consumer(_services, _options);
                cmd.Register();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(string.Concat("InitConsumer  ex : {0}" + ex.Message));
            }
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {

            return base.StopAsync(cancellationToken);
        }
    }
}
