using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class ProductVariantTranslationRepository : BaseRepository<ProductVariantTranslationModel>, IProductVariantTranslationRepository
    {
        public ProductVariantTranslationRepository(LocalWebStoreContext context) : base(context)
        {
        }
    }
}
