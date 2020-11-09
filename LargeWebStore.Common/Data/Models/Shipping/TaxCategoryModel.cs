using LargeWebStore.Common.Domain.Data;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class TaxCategoryModel : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
