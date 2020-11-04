using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(LocalWebStoreContext context) : base(context)
        {
        }

        public async Task<bool> ProductExistAsync(string name)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Translation.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
