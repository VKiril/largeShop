using LargeWebStore.Api.Services.Elastic;
using LargeWebStore.Common.Data.Repositories;
using LargeWebStore.Common.Data.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Util
{
    public static class RegisterDIExtension
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped(typeof(IElasticSearchGenericService<>), typeof(ElasticSearchGenericService<>));


            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
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
