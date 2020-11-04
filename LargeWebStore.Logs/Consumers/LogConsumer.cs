using LargeWebStore.Common.Business.Contracts.Logger;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LargeWebStore.Logs.Consumers
{
    public class LogConsumer : IConsumer<ILogConsumer>
    {
        private readonly ILogger<LogConsumer> _logger;

        public LogConsumer(ILogger<LogConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ILogConsumer> context)
        {
            Console.WriteLine("Command received: {0}", context.Message.Message);
            _logger.LogInformation("Command received: {0}", context.Message.Message);

            return Task.CompletedTask;
        }
    }
}
