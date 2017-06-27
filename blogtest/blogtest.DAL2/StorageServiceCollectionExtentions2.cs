using blogtest.DAL2.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace blogtest.DAL2
{
    public static class StorageServiceCollectionExtentions2
    {
        public static IServiceCollection AddStorageMSSQL2(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("blogtest.DAL2")));

            services.AddTransient<IEntitiesContext2, ApplicationContext>();

            
            return services;
        }

    }
}
