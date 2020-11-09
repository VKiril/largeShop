using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductVariantTranslationModel : ModelBase
    {
        public string Name { get; set; }
        public string Locale { get; set; }

        [ForeignKey("ProductVariantId")]
        public ProductVariantModel ProductVariant { get; set; }
        public Guid ProductVariantId { get; set; }
    }
}
