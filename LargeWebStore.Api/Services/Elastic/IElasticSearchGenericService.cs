using Nest;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Services.Elastic
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
        Task ReIndex(TEntity[] models);
    }
}
