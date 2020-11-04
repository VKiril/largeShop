using System;

namespace LargeWebStore.Common.Business.Contracts
{
    public interface IProductConsumer
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public bool Enabled { get; set; }
        public double Rating { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Locale { get; set; }
    }
}
