using LargeWebStore.Logs.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.Logs
{
    class Worker : BackgroundService
    {
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public Worker(IBusControl busControl, IServiceProvider serviceProvider)
        {
            _busControl = busControl;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Console.WriteLine("Logger worker. Up and running ");

                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("LogQueue", x =>
                {
                    x.Consumer<LogConsumer>(_serviceProvider);
                });

                await hostReceiveEndpointHandler.Ready;
            } catch (Exception ex)
            {
                Console.WriteLine($"Logger worker. Exception: {ex.Message}");
            } finally
            {
                Console.WriteLine("Logger worker. Bye");
            }
        }
    }
}
