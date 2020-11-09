using LargeWebStore.Common.Domain.Dtos.Product;
using MediatR;
using Newtonsoft.Json;
using System;

namespace LargeWebStore.Common.Domain.Commands.Product
{
    public class CreateTaxonCommand : CommandBase<TaxonDto>
    {
        public CreateTaxonCommand()
        {
        }

        [JsonConstructor]
        public CreateTaxonCommand(
            Guid treeRoot,
            int treeLevel,
            string code,
            string name,
            string slug,
            string description,
            string locale,
            Guid? parent
            )
        {
            TreeRoot = treeRoot;
            Parent = parent;
            TreeLevel = treeLevel;
            Code = code;
            Name = name;
            Slug = slug;
            Description = description;
            Locale = locale;
        }

        [JsonProperty("treeRoot")]
        public Guid TreeRoot { get; set; }

        [JsonProperty("parent")]
        public Guid? Parent { get; set; }

        [JsonProperty("treeLevel")]
        public int TreeLevel { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
}
