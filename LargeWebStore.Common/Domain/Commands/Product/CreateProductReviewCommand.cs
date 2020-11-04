using LargeWebStore.Common.Data.Models.Product;
using System;

namespace LargeWebStore.Common.Domain.Commands.Product
{
    public class CreateProductReviewCommand : CommandBase<ProductReviewModel>
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public Guid ProductId { get; set; }
    }
}
