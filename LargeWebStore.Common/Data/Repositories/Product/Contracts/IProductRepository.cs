using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Contracts;
using System.Threading.Tasks;

namespace LargeWebStore.Common.Data.Repositories.Product.Contracts
{
    public interface IProductRepository : IBaseRepository<ProductModel>
    {
        Task<bool> ProductExistAsync(string name);
    }
}
