using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class ProductTranslationModel : ModelBase
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Locale { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
    }
}
