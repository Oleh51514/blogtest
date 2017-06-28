using blogtest.DAL.Context;
using blogtest.DAL.Interfaces;
using blogtest.Entities.Entities;
using Microsoft.Extensions.Logging;
using storagecore.EFCore.Models;
using storagecore.EFCore.Repositories;

namespace blogtest.DAL.Repositories
{
    public class PostRepository : BaseRepository<BlogDbContext, Post, string>, IPostRepository
    {
        public PostRepository(ILogger<LoggerDataAccess> logger)
            : base(logger, null)
        {
        }        
    }
}

