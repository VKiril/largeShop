using System.Threading.Tasks;
using LargeWebStore.Api.Services.Elastic;
using LargeWebStore.Common.Business.ElasticDocuments.Product;
using LargeWebStore.Common.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;

namespace LargeWebStore.Api.Controllers
{
    public class ProductController : ApiBaseController
    {
        private readonly IElasticSearchGenericService<ProductDocument> _elasticService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger, IElasticSearchGenericService<ProductDocument> elasticService) : base(mediator)
        {
            _elasticService = elasticService;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Find(string query)
        {
            int page = 1;
            int pageSize = 5;

            var response = await _elasticService.SearchAsync(query, page, pageSize);

            if (!response.IsValid)
            {
                _logger.LogError("Failed to search documents by query {0}", query);
            }
            return Ok(response.Documents);
        }



    }
}
