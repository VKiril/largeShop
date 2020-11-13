using LargeWebStore.Common.Domain.Dtos.Product;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace LargeWebStore.Common.Domain.Commands.Product
{
    public class CreateProductCommand : CommandBase<ProductDto>
    {
        public CreateProductCommand()
        {
        }

        [JsonConstructor]
        public CreateProductCommand(
            Guid taxonId,
            string code,
            bool enabled,
            bool shippingRequired,
            float price,
            double rating,
            string name,
            string variantName,
            string slug,
            string metaKeywords,
            string description,
            string shortDescription,
            string locale,
            float width,
            float height,
            float depth,
            float weight,
            string attributes,
            int quantity
            )
        {
            TaxonId = taxonId;
            Code = code;
            Enabled = enabled;
            ShippingRequired = shippingRequired;
            Price = price;
            Rating = rating;
            Name = name;
            VariantName = variantName;
            Slug = slug;
            MetaKeywords = metaKeywords;
            Description = description;
            ShortDescription = shortDescription;
            Locale = locale;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            Attributes = attributes;
            Quantity = quantity;
        }

        [JsonProperty("taxonId")]
        [Required]
        public Guid TaxonId { get; set; }

        [JsonProperty("code")]
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; } = true;

        [JsonProperty("shippingRequired")]
        public bool? ShippingRequired { get; set; } = true;

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("rating")]
        [Required]
        public double Rating { get; set; }

        [JsonProperty("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [JsonProperty("variantName")]
        public string VariantName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("metaKeyword")]
        public string MetaKeywords { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("description")]
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [JsonProperty("shortDescription")]
        [Required]
        [MaxLength(255)]
        public string ShortDescription { get; set; }

        [JsonProperty("locale")]
        [Required]
        [MaxLength(10)]
        public string Locale { get; set; }

        [JsonProperty("width")]
        public float Width { get; set; }

        [JsonProperty("height")]
        public float Height { get; set; }

        [JsonProperty("depth")]
        public float Depth { get; set; }

        [JsonProperty("weight")]
        public float Weight { get; set; }

        [JsonProperty("Attributes")]
        public string Attributes { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
    }
}
