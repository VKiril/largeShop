using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class TaxRateModel : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public bool IsIncludedInPrice { get; set; }
        public string Calculator { get; set; }
        public Guid TaxCategoryId { get; set; }

        [ForeignKey("TaxCategoryId")]
        public TaxCategoryModel TaxCategory { get; set; }
    }
}
