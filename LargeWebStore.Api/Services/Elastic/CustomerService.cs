using LargeWebStore.Common.Domain.Data;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Services.Elastic
{
    public class CustomerService : ICustomerService
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IElasticClient elasticClient, ILogger<CustomerService> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task<GetResponse<CustomerModel>> GetAsync(int id)
        {
            var response = await _elasticClient.GetAsync<CustomerModel>(id);

            return response;
        }

        public async Task<ISearchResponse<CustomerModel>> SearchAsync(string query, int page = 1, int pageSize = 5)
        {
            var response = await _elasticClient.SearchAsync<CustomerModel>(
                 s => s.Query(q => q.QueryString(d => d.Query('*' + query + '*')))
                     .From((page - 1) * pageSize)
                     .Size(pageSize));

            if (!response.IsValid)
            {
                _logger.LogError("Failed to search documents by query {0}", query);
            }

            return response;
        }

        public async Task DeleteAsync(CustomerModel model)
        {
            await _elasticClient.DeleteAsync<CustomerModel>(model);
        }

        public async Task ReIndex(CustomerModel[] models)
        {
            await _elasticClient.DeleteByQueryAsync<CustomerModel>(q => q.MatchAll());

            foreach(var model in models)
            {
                await _elasticClient.IndexDocumentAsync(model);
            }
        }

        public async Task SaveBulkAsync(CustomerModel[] models)
        {
            var result = await _elasticClient.BulkAsync(b => b.Index("customers").IndexMany(models));

            if (result.Errors)
            {
                foreach(var error in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}", error.Id, error.Error);
                }
            }
        }

        public async Task SaveManyAsync(CustomerModel[] models)
        {
            var result = await _elasticClient.IndexManyAsync(models);

            if (result.Errors)
            {
                foreach (var error in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}", error.Id, error.Error);
                }
            }
        }

        /// <summary>
        /// Add a customer to elasticsearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task SaveSingleAsync(CustomerModel model)
        {
            if (_elasticClient.DocumentExists<CustomerModel>(model).Exists)
            {
                await _elasticClient.UpdateAsync<CustomerModel>(model, u => u.Doc(model));
            }
            else
            {
                await _elasticClient.IndexDocumentAsync(model);
            }
        }
    }
}
