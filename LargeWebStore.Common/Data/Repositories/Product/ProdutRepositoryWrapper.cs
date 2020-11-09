using LargeWebStore.Common.Data.Repositories.Product.Contracts;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class ProdutRepositoryWrapper : IProdutRepositoryWrapper
    {
        public IProductRepository ProductRepository { get; set; }
        public IProductTranslationRepository ProductTranslationRepository { get; set; }
        public IProductVariantRepository ProductVariantRepository { get; set; }
        public IProductVariantTranslationRepository ProductVariantTranslationRepository { get; set; }
        public ITaxonRepository TaxonRepository { get; set; }
        
        public ProdutRepositoryWrapper(IProductRepository productRepository, 
            IProductTranslationRepository productTranslationRepository, 
            IProductVariantRepository productVariantRepository,
            IProductVariantTranslationRepository productVariantTranslationRepository)
        {
            ProductRepository = productRepository;
            ProductTranslationRepository = productTranslationRepository;
            ProductVariantRepository = productVariantRepository;
            ProductVariantTranslationRepository = productVariantTranslationRepository;
        }
    }
}
