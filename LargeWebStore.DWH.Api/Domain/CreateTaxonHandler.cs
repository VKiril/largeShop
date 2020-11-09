using LargeWebStore.Common.Business.Contracts.Logger;
using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using LargeWebStore.Common.Domain.Commands.Product;
using LargeWebStore.Common.Domain.Dtos.Product;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.DWH.Api.Domain
{
    public class CreateTaxonHandler : IRequestHandler<CreateTaxonCommand, TaxonDto>
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly ITaxonRepository _taxonRepository;
        private readonly ITaxonTranslationRepository _taxonTranslationRepository;

        public CreateTaxonHandler(IPublishEndpoint endpoint, ITaxonRepository taxonRepository, ITaxonTranslationRepository taxonTranslationRepository)
        {
            _endpoint = endpoint;
            _taxonRepository = taxonRepository;
            _taxonTranslationRepository = taxonTranslationRepository;
        }

        public async Task<TaxonDto> Handle(CreateTaxonCommand request, CancellationToken cancellationToken)
        {
            var taxon = new TaxonModel
            {
                Code = request.Code,
                Parent = request.Parent,
                TreeLevel = request.TreeLevel,
                TreeRoot = request.TreeRoot
            };
            _taxonRepository.Add(taxon);
            await _taxonRepository.SaveChangesAsync();

            var taxonTranslation = new TaxonTranslationModel
            {
                Description = request.Description,
                Locale = request.Locale,
                Name = request.Name,
                Slug = request.Slug,
                Taxon = taxon
            };

            _taxonTranslationRepository.Add(taxonTranslation);
            await _taxonTranslationRepository.SaveChangesAsync();

            string jsonString = JsonConvert.SerializeObject(request);
            await _endpoint.Publish<ILogConsumer>(new { Message = jsonString });

            var result = new TaxonDto
            {
                Code = request.Code,
                Description = request.Description,
                Locale = request.Locale,
                Name = request.Name,
                Slug = request.Slug
            };

            return result;
        }
    }
}
