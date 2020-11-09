using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class ShippingMethodTranslationModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }
        public Guid ShippingMethodId { get; set; }

        [ForeignKey("ShippingMethodId")]
        public ShippingMethodModel ShippingMethod { get; set; }
    }
}
