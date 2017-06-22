using blogtest.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace blogtest.DAL
{
    public static class StorageServiceCollectionExtentions
    {
        public static IServiceCollection AddStorageMSSQL(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("blogtest.DAL")));

            return services;
        }

    }
}
