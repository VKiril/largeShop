using System;

namespace LargeWebStore.Common.Domain.Dtos.Product
{
    public class TaxonDto
    {
        public Guid TreeRoot { get; set; }
        public Guid? Parent { get; set; }
        public int TreeLevel { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }
    }
}
