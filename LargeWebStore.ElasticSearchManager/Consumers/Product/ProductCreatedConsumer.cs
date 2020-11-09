using LargeWebStore.Common.Business.Contracts;
using LargeWebStore.Common.Business.ElasticDocuments.Product;
using LargeWebStore.ElasticSearchManager.Services;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.ElasticSearchManager.Consumers.Product
{
    public class ProductCreatedConsumer : IConsumer<IProductConsumer>
    {
        private readonly IElasticSearchGenericService<ProductDocument> _elasticService;
        private readonly ILogger<ProductCreatedConsumer> _logger;

        public ProductCreatedConsumer(ILogger<ProductCreatedConsumer> logger, IElasticSearchGenericService<ProductDocument> elasticService)
        {
            _logger = logger;
            _elasticService = elasticService;
        }

        public async Task Consume(ConsumeContext<IProductConsumer> context)
        {
            _logger.LogInformation("ProductCreatedConsumer Command received: {0}", context.Message.Code);

            var document = new ProductDocument
            {
                Id = 1,
                Code = context.Message.Code,
                Description = context.Message.Description,
                Enabled = (bool)context.Message.Enabled,
                Locale = context.Message.Locale,
                Name = context.Message.Name,
                Rating = context.Message.Rating,
                ShortDescription = context.Message.ShortDescription
            };

            //await _elasticService.SaveBulkAsync(new ProductDocument[] { document }, "products");
            await _elasticService.SaveSingleAsync(document);
            _logger.LogInformation("Elastic search document created");
        }
    }
}
