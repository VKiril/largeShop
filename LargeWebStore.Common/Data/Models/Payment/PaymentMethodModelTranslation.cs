using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Payment
{
    public class PaymentMethodModelTranslation : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Locale { get; set; }
        public Guid PaymentId { get; set; }

        public PaymentModel Payment { get; set; }
    }
}
