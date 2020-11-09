using Microsoft.Extensions.Logging;
using Nest;
using System.Threading.Tasks;

namespace LargeWebStore.ElasticSearchManager.Services
{
    public class ElasticSearchGenericService<TEntity> : IElasticSearchGenericService<TEntity> where TEntity : class
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<ElasticSearchGenericService<TEntity>> _logger;

        public ElasticSearchGenericService(IElasticClient elasticClient, ILogger<ElasticSearchGenericService<TEntity>> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task<GetResponse<TEntity>> GetAsync(int id)
        {
            var response = await _elasticClient.GetAsync<TEntity>(id);

            return response;
        }

        public async Task<ISearchResponse<TEntity>> SearchAsync(string query, int page = 1, int pageSize = 5)
        {
            var response = await _elasticClient.SearchAsync<TEntity>(
                 s => s.Query(q => q.QueryString(d => d.Query('*' + query + '*')))
                     .From((page - 1) * pageSize)
                     .Size(pageSize));

            if (!response.IsValid)
            {
                _logger.LogError("Failed to search documents by query {0}", query);
            }

            return response;
        }

        public async Task DeleteAsync(TEntity model)
        {
            await _elasticClient.DeleteAsync<TEntity>(model);
        }

        public async Task ReIndex(TEntity[] models)
        {
            await _elasticClient.DeleteByQueryAsync<TEntity>(q => q.MatchAll());

            foreach (var model in models)
            {
                await _elasticClient.IndexDocumentAsync(model);
            }
        }

        public async Task SaveBulkAsync(TEntity[] models)
        {
            string name = typeof(TEntity).FullName;
            var result = await _elasticClient.BulkAsync(b => b.Index(name).IndexMany(models));

            if (result.Errors)
            {
                foreach (var error in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}", error.Id, error.Error);
                }
            }
        }

        public async Task SaveBulkAsync(TEntity[] models, string indexName)
        {
            string name = typeof(TEntity).FullName;
            var result = await _elasticClient.BulkAsync(b => b.Index(indexName).IndexMany(models));

            if (result.Errors)
            {
                foreach (var error in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}", error.Id, error.Error);
                }
            }
        }

        public async Task SaveManyAsync(TEntity[] models)
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
        public async Task SaveSingleAsync(TEntity model)
        {
            if (_elasticClient.DocumentExists<TEntity>(model).Exists)
            {
                await _elasticClient.UpdateAsync<TEntity>(model, u => u.Doc(model));
            }
            else
            {
                await _elasticClient.IndexDocumentAsync(model);
            }
        }
    }
}
