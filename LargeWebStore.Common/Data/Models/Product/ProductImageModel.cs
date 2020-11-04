using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductImageModel : ModelBase
    {
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
    }
}
