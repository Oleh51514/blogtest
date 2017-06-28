using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using storagecore.EFCore.Entities;
using storagecore.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace storagecore.EFCore.Repositories
{
    public class GenericRepository<TEntity, TKey> : BaseRepository<DbContext, TEntity, TKey>
       where TEntity : BaseEntity<TKey>, new()
    {
        public GenericRepository(ILogger<LoggerDataAccess> logger) : base(logger, null)
        {

        }
    }
}
