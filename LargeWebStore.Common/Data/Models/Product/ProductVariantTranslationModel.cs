using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductVariantTranslationModel : ModelBase
    {
        public string Name { get; set; }
        public string Locale { get; set; }

        public ProductVariantModel Translatable { get; set; }
    }
}
