using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Payment
{
    public class OrderModel : ModelBase
    {
        public string Number { get; set; }
        public string Notes { get; set; }
        public string State { get; set; }
        public DateTime CheckoutCompletedAt { get; set; }
        public int ItemsTotal { get; set; }
        public int AdjustmentsTotal { get; set; }
        public int Total { get; set; }
        public string CurrencyCode { get; set; }
        public string LocaleCode { get; set; }
        public string CheckoutState { get; set; }
        public string PaymentState { get; set; }
        public string ShippingState { get; set; }
        public string CustomerIp { get; set; }
    }
}
