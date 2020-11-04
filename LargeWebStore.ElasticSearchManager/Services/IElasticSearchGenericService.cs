using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LargeWebStore.ElasticSearchManager.Services
{
    public interface IElasticSearchGenericService<TEntity> 
        where TEntity : class
    {
        Task<GetResponse<TEntity>> GetAsync(int id);
        Task<ISearchResponse<TEntity>> SearchAsync(string query, int page = 1, int pageSize = 5);
        Task DeleteAsync(TEntity model);
        Task SaveSingleAsync(TEntity product);
        Task SaveManyAsync(TEntity[] models);
        Task SaveBulkAsync(TEntity[] models);
        Task SaveBulkAsync(TEntity[] models, string indexName);
        Task ReIndex(TEntity[] models);
    }
}
