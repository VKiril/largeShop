namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductDto : DtoBase
    {
        public string Code { get; set; }
        public bool Enabled { get; set; }
        public double Rating { get; set; }
        public ProductTranslationDto Translation { get; set; }
        public ProductImageDto Image { get; set; }
    }
}
