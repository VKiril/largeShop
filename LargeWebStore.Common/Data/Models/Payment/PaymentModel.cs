using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Payment
{
    public class PaymentModel : ModelBase
    {
        public string CurrencyCode { get; set; }
        public int Amount { get; set; }
        public string State { get; set; }
        public string Details { get; set; }
    }
}
