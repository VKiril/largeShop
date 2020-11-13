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
        private readonly IProdutRepositoryWrapper _productRepository;
        private readonly IProductTranslationRepository _productTranslationRepository;

        public CreateProductHandler(IPublishEndpoint endpoint, IProdutRepositoryWrapper productRepository, 
            IProductTranslationRepository productTranslationRepository)
        {
            _endpoint = endpoint;
            _productRepository = productRepository;
            _productTranslationRepository = productTranslationRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // create product variant
            // create product translation
            // create product

            // save them
            // publish message
            // save logs
            // return result 

            var product = new ProductModel
            {
                TaxonId = request.TaxonId,
                Code = request.Code,
                Enabled = request.Enabled ?? true,
                Rating = request.Rating,
            };
            _productRepository.ProductRepository.Add(product);
            await _productRepository.ProductRepository.SaveChangesAsync();


            var productTranslation = new ProductTranslationModel
            {
                Name = request.Name,
                Description = request.Description,
                Locale = request.Locale,
                ShortDescription = request.ShortDescription,
                Slug = request.Name.ToLower().Replace(" ", "_"),
                Product = product
            };
            _productRepository.ProductTranslationRepository.Add(productTranslation);
            await _productRepository.ProductTranslationRepository.SaveChangesAsync();

            var productVariant = new ProductVariantModel
            {
                Code = request.Code + "-variant",
                Depth = request.Depth,
                ShippingRequired = (bool)request.ShippingRequired,
                Weight = request.Weight,
                Height = request.Height,
                Width = request.Width,
                Product = product,
            };


            var productVariantTranslation = new ProductVariantTranslationModel
            {
                Name = request.VariantName,
                Locale = request.Locale,
                ProductVariant = productVariant
            };

            _productRepository.ProductVariantTranslationRepository.Add(productVariantTranslation);
            await _productRepository.ProductVariantTranslationRepository.SaveChangesAsync();

            _productRepository.ProductVariantRepository.Add(productVariant);
            await _productRepository.ProductRepository.SaveChangesAsync();

            string jsonString = JsonConvert.SerializeObject(request);
            await _endpoint.Publish<ILogConsumer>(new { Message = jsonString });
            await _endpoint.Publish<IProductConsumer>(
                new { 
                    Id = product.Id,
                    Code = request.Code,
                    Enabled = request.Enabled,
                    ShippingRequired = request.ShippingRequired,
                    Price = request.Price,
                    Rating = request.Rating,
                    Name = request.Name,
                    Slug = request.Slug,
                    MetaKeywords = request.MetaKeywords,
                    Description = request.Description,
                    ShortDescription = request.ShortDescription,
                    Locale = request.Locale,
                    Width = request.Width,
                    Height = request.Height,
                    Depth = request.Depth,
                    Weight = request.Weight,
                    Attributes = request.Attributes,
                    Quantity = request.Quantity,
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
