using blogtest.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using blogtest.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;
using blogtest.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using blogtest.DAL.Interfaces;

namespace blogtest.DAL
{
    public static class StorageServiceCollectionExtentions
    {
        public static IServiceCollection AddStorageMSSQL(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddTransient<IEntitiesContext, BlogDbContext>();
            services.AddTransient<BlogDbContext, BlogDbContext>();
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("blogtest.DAL")));

            AddIdentity(services);
            AddRepositories(services);

            return services;
        }

        private static void AddIdentity(IServiceCollection services)
        {
            // Configurations for Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<BlogDbContext>()
            .AddDefaultTokenProviders();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }

    }
}
