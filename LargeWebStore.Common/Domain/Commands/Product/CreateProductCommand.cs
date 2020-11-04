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
        public CreateProductCommand(string code, bool enabled, double rating, string name, 
            string description, string shortDeescription, string locale)
        {
            Code = code;
            Enabled = enabled;
            Rating = rating;
            Name = name;
            Description = description;
            ShortDescription = shortDeescription;
            Locale = locale;
        }

        [JsonProperty("code")]
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; } = true;

        [JsonProperty("rating")]
        [Required]
        public double Rating { get; set; }

        [JsonProperty("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [JsonProperty("description")]
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [JsonProperty("short_description")]
        [Required]
        [MaxLength(255)]
        public string ShortDescription { get; set; }

        [JsonProperty("locale")]
        [Required]
        [MaxLength(10)]
        public string Locale { get; set; }
    }
}
