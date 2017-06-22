using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Test
{
    public static class StorageServiceCollectionExtentions
    {
        public static IServiceCollection AddStorageMSSQL(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddDbContext<MobileContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }

    }
}
