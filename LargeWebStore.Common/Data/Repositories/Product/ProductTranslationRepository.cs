using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class ProductTranslationRepository : BaseRepository<ProductTranslationModel>, IProductTranslationRepository
    {
        public ProductTranslationRepository(LocalWebStoreContext context) : base(context)
        {
        }
    }
}
