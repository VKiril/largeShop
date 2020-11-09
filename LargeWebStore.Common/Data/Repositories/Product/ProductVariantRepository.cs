using LargeWebStore.Common.Data.Models.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Repositories.Product
{
    public class ProductVariantRepository : BaseRepository<ProductVariantModel>, IProductVariantRepository
    {
        public ProductVariantRepository(LocalWebStoreContext context) : base(context)
        {
        }
    }
}
