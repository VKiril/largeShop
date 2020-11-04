using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductModel : ModelBase
    {
        public string Code { get; set; }
        public bool Enabled { get; set; }
        public double Rating { get; set; }
        public ProductTranslationModel Translation { get; set; }
        public ProductImageModel Image { get; set; }
    }
}
