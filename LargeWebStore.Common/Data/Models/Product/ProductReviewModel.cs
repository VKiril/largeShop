using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductReviewModel : ModelBase
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
    }
}
