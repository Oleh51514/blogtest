﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using storagecore.Abstractions.Context;
using storagecore.Abstractions.Repositories;
using storagecore.Abstractions.Uow;
using storagecore.EFCore.Paging;
using storagecore.EFCore.Repositories;
using storagecore.EFCore.Uow;

namespace storagecore.EFCore
{
    public static class StorageCoreServiceCollectionExtentions
    {
        public static IServiceCollection AddStorageCoreDataAccess<TEntityContext>(
            this IServiceCollection services
        ) where TEntityContext : DbContext, IEntityContext
        {
            RegisterStorageCoreDataAccess<TEntityContext>(services);
            return services;
        }

        private static void RegisterStorageCoreDataAccess<TEntityContext>(IServiceCollection services) where TEntityContext : DbContext, IEntityContext
        {
            services.TryAddSingleton<IUowProvider, UowProvider>();
            services.TryAddTransient<IEntityContext, TEntityContext>();
            services.TryAddTransient(typeof(IBaseRepository<,>), typeof(GenericRepository<,>));
            services.TryAddTransient(typeof(IDataPager<,>), typeof(DataPager<,>));
        }
    }
}
