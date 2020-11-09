namespace LargeWebStore.Common.Data.Repositories.Product.Contracts
{
    public interface IProdutRepositoryWrapper
    {
        IProductRepository ProductRepository { get; set; }
        IProductTranslationRepository ProductTranslationRepository { get; set; }
        IProductVariantRepository ProductVariantRepository { get; set; }
        IProductVariantTranslationRepository ProductVariantTranslationRepository { get; set; }
        ITaxonRepository TaxonRepository { get; set; }
    }
}
