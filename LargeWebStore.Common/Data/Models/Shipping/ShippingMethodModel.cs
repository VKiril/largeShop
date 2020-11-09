using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class ShippingMethodModel : ModelBase
    {
        public string Code { get; set; }
        public string Configuration { get; set; }
        public bool IsEnabled { get; set; }
    }
}
