using LargeWebStore.Common.Domain.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class TaxonTranslationModel : ModelBase
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }

        [ForeignKey("TaxonId")]
        public TaxonModel Taxon { get; set; }
        public Guid TaxonId { get; set; }
    }
}
