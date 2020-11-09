using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class TaxonTranslationRepository : BaseRepository<TaxonTranslationModel>, ITaxonTranslationRepository
    {
        public TaxonTranslationRepository(LocalWebStoreContext context) : base(context)
        {
        }
    }
}
