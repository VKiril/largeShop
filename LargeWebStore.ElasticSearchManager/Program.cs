using LargeWebStore.ElasticSearchManager.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LargeWebStore.ElasticSearchManager
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

                    services.RegisterQueueServices(configuration);
                    services.AddElasticSearch(configuration);
                    services.RegisterDI();

                    services.AddHostedService<Worker>();
                });
        }
    }
}
