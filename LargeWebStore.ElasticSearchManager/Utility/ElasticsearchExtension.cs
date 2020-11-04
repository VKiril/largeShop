using LargeWebStore.Common.Business.ElasticDocuments.Product;
using LargeWebStore.Common.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace LargeWebStore.ElasticSearchManager.Utility
{
    public static class ElasticsearchExtension
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["Elasticsearch:url"];
            var defaultIndex = configuration["Elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url));

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);

            return services;
        }

        private static void CreateIndex(ElasticClient client, string indexName)
        {
            //var createIndexResponse = client.Indices
            //    .Create(indexName,
            //        index => index.Map<CustomerModel>(x => x.AutoMap())
            //    );

            var createIndexResponse2 = client.Indices
                .Create(indexName,
                    index => index.Map<ProductDocument>(x => x.AutoMap())
                );
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.
                DefaultMappingFor<ProductDocument>(m => m.
                    Ignore(p => p.Id)
                );
        }
    }
}
