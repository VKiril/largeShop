using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Domain.Commands.Product
{
    public class CreateProductImageCommand : CommandBase<ProductImageModel>
    {
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}
