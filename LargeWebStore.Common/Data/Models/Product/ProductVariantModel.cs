using LargeWebStore.Common.Data.Models.Shipping;
using LargeWebStore.Common.Domain.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductVariantModel : ModelBase
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
        public bool IsOnHold { get; set; }
        public bool IsOnHand { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
        public Guid ProductId { get; set; }

        public Guid TranslationId { get; set; }

        [ForeignKey("TaxCategoryId")]
        public TaxCategoryModel TaxCategory { get; set; }
        public Guid? TaxCategoryId { get; set; }
    }
}
