using LargeWebStore.Common.Data.Models.Product;
using System;

namespace LargeWebStore.Common.Domain.Commands.Product
{
    public class CreateProductVariantCommand : CommandBase<ProductVariantModel>
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
        public string Name { get; set; }
        public string Locale { get; set; }
        public Guid ProductId { get; set; }
    }
}
