using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Domain.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LargeWebStore.Common.Data.Models.Payment
{
    public class OrderItemModel : ModelBase
    {
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsTotal { get; set; }
        public int AdjustmentsTotal { get; set; }
        public int Total { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderModel Order { get; set; }

        public Guid ProductVariantId { get; set; }

        [ForeignKey("ProductVariantId")]
        public ProductVariantModel ProductVariant { get; set; }
    }
}
