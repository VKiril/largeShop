using LargeWebStore.ElasticSearchManager.Consumers.Product;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.ElasticSearchManager
{
    public class Worker : BackgroundService
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

                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("ElasticQueue", x =>
                {
                    x.Consumer<ProductCreatedConsumer>(_serviceProvider);
                });

                await hostReceiveEndpointHandler.Ready;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logger worker. Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Logger worker. Bye");
            }
        }
    }
}
