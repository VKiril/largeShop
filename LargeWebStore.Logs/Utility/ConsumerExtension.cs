using LargeWebStore.Common.Business.Util;
using LargeWebStore.Logs.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Logs.Utility
{
    public static class ConsumerExtension
    {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services, IConfiguration config)
        {
            var queueSettings = new QueueSettings();
            config.GetSection("QueueSettings").Bind(queueSettings);

            services.AddMassTransit(c =>
            {
                c.AddConsumer<LogConsumer>();
            });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(queueSettings.HostName, queueSettings.VirtualHost, h => {
                    h.Username(queueSettings.UserName);
                    h.Password(queueSettings.Password);
                });

                //cfg.ReceiveEndpoint("account-service", e =>
                //{
                //    e.Lazy = true;
                //    e.Consumer<LogConsumer>();
                //});

                //cfg.SetLoggerFactory(provider.GetService<ILoggerFactory>());
            }));



            return services;
        }
    }
}
