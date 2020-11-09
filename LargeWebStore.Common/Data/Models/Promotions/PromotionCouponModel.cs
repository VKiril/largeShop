using LargeWebStore.Common.Domain.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LargeWebStore.Common.Data.Models.Promotions
{
    public class PromotionCouponModel : ModelBase
    {
        public string Code { get; set; }
        public int UsageLimit { get; set; }
        public int Used { get; set; }
        public DateTime ExpireAt { get; set; }
        public int PerCustomerUsageLimit { get; set; }
        public Guid PromotionId { get; set; }

        [ForeignKey("PromotionId")]
        public PromotionModel Promotion { get; set; }
    }
}
