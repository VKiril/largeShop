using System;

namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductImageDto : DtoBase
    {
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
