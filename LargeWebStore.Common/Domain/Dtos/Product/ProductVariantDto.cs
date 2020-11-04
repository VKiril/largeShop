namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductVariantDto : DtoBase
    {
        public string Code { get; set; }
        public int Position { get; set; }
        public int Version { get; set; }
        public bool Tracked { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public bool ShippingRequired { get; set; }
        public ProductDto Product { get; set; }
        public ProductVariantTranslationDto Translation { get; set; }
    }
}
