using LargeWebStore.Common.Business.Util;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace LargeWebStore.DWH.Api.Util
{
    public static class QueueExtension
    {
        public static IServiceCollection RegisterQueueServices (this IServiceCollection services, IConfiguration configuration)
        {
            var queueSettings = new QueueSettings();
            configuration.GetSection("QueueSettings").Bind(queueSettings);

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(queueSettings.HostName, queueSettings.VirtualHost, h =>
                {
                    h.Username(queueSettings.UserName);
                    h.Password(queueSettings.Password);
                });

                cfg.ExchangeType = ExchangeType.Fanout;
            }));

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }
    }
}
