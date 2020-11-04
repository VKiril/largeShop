namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductVariantTranslationDto : DtoBase
    {
        public string Name { get; set; }
        public string Locale { get; set; }
        public ProductVariantDto Translatable { get; set; }
    }
}
