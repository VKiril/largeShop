using System;

namespace LargeWebStore.Common.Business.Contracts
{
    public interface IProductConsumer
    {
        string Code { get; set; }
        bool? Enabled { get; set; }
        bool? ShippingRequired { get; set; }
        float Price { get; set; }
        double Rating { get; set; }
        string Name { get; set; }
        string Slug { get; set; }
        string MetaKeywords { get; set; }
        string MetaDescription { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }
        string Locale { get; set; }
        float Width { get; set; }
        float Height { get; set; }
        float Depth { get; set; }
        float Weight { get; set; }
        string Attributes { get; set; }
        int Quantity { get; set; }
    }
}
