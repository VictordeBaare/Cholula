using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BoilerPlateCore.Worker.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int counter = 0;
            return Task.Run(() =>
            {
                try
                {
                    while (counter < 100)
                    {
                        Console.WriteLine($"Counter is {counter}");
                        counter++;
                    }

                    throw new ArgumentException("Exception to test logging");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error occured in the Worker");

                    Environment.ExitCode = 1;
                }
                finally
                {
                    _applicationLifetime.StopApplication();
                }
            });                    
        }        
    }
}
