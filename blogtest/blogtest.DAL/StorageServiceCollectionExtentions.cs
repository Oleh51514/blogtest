using blogtest.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using blogtest.DAL.Repositories;

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

            services.AddTransient<IEntitiesContext, BlogDbContext>();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            return services;
        }

    }
}
