namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductReviewDto : DtoBase
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public ProductDto Product { get; set; }
    }
}
