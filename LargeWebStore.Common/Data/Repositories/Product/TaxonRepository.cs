using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class TaxonRepository : BaseRepository<TaxonModel>, ITaxonRepository
    {
        public TaxonRepository(LocalWebStoreContext context) : base(context)
        {
        }
    }
}
