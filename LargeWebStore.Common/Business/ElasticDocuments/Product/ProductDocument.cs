using Nest;

namespace LargeWebStore.Common.Business.ElasticDocuments.Product
{
    [ElasticsearchType(IdProperty = "Id")]
    public class ProductDocument
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Enabled { get; set; }
        [Number]
        public double Rating { get; set; }
        [Keyword]
        public string Name { get; set; }
        [Keyword]
        public string Description { get; set; }
        [Keyword]
        public string ShortDescription { get; set; }
        public string Locale { get; set; }
    }
}
