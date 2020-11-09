using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Payment
{
    public class PaymentMethodModel : ModelBase
    {
        public string Code { get; set; }
        public string Environment { get; set; }
        public bool IsEnabled { get; set; }
        public int Position { get; set; }
    }
}
