using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class ProductTranslationDto : DtoBase
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Locale { get; set; }
        public ProductDto Product { get; set; }
    }
}
