using LargeWebStore.Common.Business.Contracts;
using LargeWebStore.Common.Business.Contracts.Logger;
using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using LargeWebStore.Common.Domain.Commands.Product;
using LargeWebStore.Common.Domain.Dtos.Product;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.DWH.Api.Domain
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly IProductRepository _productRepository;
        private readonly IProductTranslationRepository _productTranslationRepository;

        public CreateProductHandler(IPublishEndpoint endpoint, IProductRepository productRepository, 
            IProductTranslationRepository productTranslationRepository)
        {
            _endpoint = endpoint;
            _productRepository = productRepository;
            _productTranslationRepository = productTranslationRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //todo: either use automaper or create smth own
            var product = new ProductModel
            {
                Code = request.Code,
                Enabled = request.Enabled ?? true,
                Rating = request.Rating,
            };

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            var productTranslation = new ProductTranslationModel
            {
                Product = product,
                ProductId = product.Id,
                Name = request.Name,
                Description = request.Description,
                Locale = request.Locale,
                ShortDescription = request.ShortDescription,
                Slug = request.Name.ToLower().Replace(" ", "_"),
            };

            _productTranslationRepository.Add(productTranslation);
            await _productTranslationRepository.SaveChangesAsync();

            string jsonString = JsonConvert.SerializeObject(request);
            await _endpoint.Publish<ILogConsumer>(new { Message = jsonString });
            await _endpoint.Publish<IProductConsumer>(
                new { 
                    Id = product.Id, 
                    Code = product.Code, 
                    Rating = product.Rating, 
                    Enabled = product.Enabled, 
                    Name = productTranslation.Name, 
                    Description = productTranslation.Description,
                    ShortDescription = productTranslation.ShortDescription,
                    Locale = productTranslation.Locale
                }
            );

            var result = new ProductDto
            {
                Code = product.Code,
                Rating = product.Rating,
                Enabled = product.Enabled
            };

            return result;
        }
    }
}
