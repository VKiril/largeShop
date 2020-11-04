using LargeWebStore.Common.Data.Repositories;
using LargeWebStore.Common.Data.Repositories.Contracts;
using LargeWebStore.Common.Data.Repositories.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using LargeWebStore.ElasticSearchManager.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.ElasticSearchManager.Utility
{
    public static class RegisterDIExtension
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IElasticSearchGenericService<>), typeof(ElasticSearchGenericService<>));
            services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();

            return services;
        }
    }
}
