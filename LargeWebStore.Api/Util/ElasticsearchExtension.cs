using LargeWebStore.Common.Business.ElasticDocuments.Product;
using LargeWebStore.Common.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Util
{
    public static class ElasticsearchExtension
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["Elasticsearch:url"];
            var defaultIndex = configuration["Elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);

            return services;
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                //.DefaultMappingFor<CustomerModel>(m => m.Ignore(p => p.Id))
                .DefaultMappingFor<ProductDocument>(m => m.Ignore(p => p.Id))
            ;
        }

        private static void CreateIndex(ElasticClient client, string indexName)
        {
            var createIndexResponse = client
                .Indices.Create(indexName, 
                index => index.Map<ProductDocument>(x => x.AutoMap())
                //index => index.Map<CustomerModel>(x => x.AutoMap())
            );
        }
    }
}
