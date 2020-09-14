using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
            private readonly ILogger<Worker> _logger;
             public Worker(ILogger<Worker> logger)
            {
                _logger = logger;
            }

            public override Task StartAsync(CancellationToken cancellationToken)
            {

                _logger.LogInformation("The service has been started.");
                return base.StartAsync(cancellationToken);
            }

            public override Task StopAsync(CancellationToken cancellationToken)
            {
            
                _logger.LogInformation("The service has been stopped.");
                return base.StopAsync(cancellationToken);
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)

            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    Random randomNumber = new Random();
                    var number = randomNumber.Next(-50, 30);
                
                    try
                    {
                        if (number > -20)
                            _logger.LogInformation($"Wheater is fine. Temperature are {number} °C");
                        else
                            _logger.LogInformation($"It's cold outside today. Temperature are {number} °C");

                    }
                    catch
                    {
                        _logger.LogInformation("Fail");
                    }

                await Task.Delay(60 * 1000, stoppingToken);
            }
        }
    }
}