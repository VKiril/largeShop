using LargeWebStore.Common.Data.Repositories;
using LargeWebStore.Common.Data.Repositories.Contracts;
using LargeWebStore.Common.Data.Repositories.Product;
using LargeWebStore.Common.Data.Repositories.Product.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.DWH.Api.Util
{
    public static class RegisterDIExtension
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(configure =>
            {
                configure.PostProcess = (document) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Web Store";
                    document.Info.Description = ".NET Core Web API";
                };
            });

            return services;
        }
    }
}
