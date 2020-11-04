using LargeWebStore.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LargeWebStore.Common.Infrastructure.Extensions
{
    public static class PostgreSqlExtension
    {
        public static IServiceCollection AddDbInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LocalWebStoreContext>(options =>
                   options.UseNpgsql(
                       configuration.GetConnectionString("DefaultConnection"),
                       x => x.MigrationsAssembly(typeof(LocalWebStoreContext).Assembly.FullName)
                   ));

            return services;
        }
    }
}
