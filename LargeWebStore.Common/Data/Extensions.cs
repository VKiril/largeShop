using LargeWebStore.Common.Data.Repositories;
using LargeWebStore.Common.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace LargeWebStore.Common.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDbInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LocalWebStoreContext>(options =>
                   options.UseNpgsql(
                       configuration.GetConnectionString("DefaultConnection"),
                       x => x.MigrationsAssembly(typeof(LocalWebStoreContext).Assembly.FullName)
                   ));

            // Register DI
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
