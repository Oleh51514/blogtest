using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using blogtest.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using blogtest.Entities.Entities;
using blogtest.DAL.Interfaces;
using storagecore.EFCore.Repositories;
using Microsoft.Extensions.Logging;
using storagecore.EFCore.Models;

namespace blogtest.DAL.Repositories
{
    public class CommentRepository : BaseRepository<BlogDbContext, Comment, string>, ICommentRepository
    {
        public CommentRepository(ILogger<LoggerDataAccess> logger)
            : base(logger, null)
        {
        }        
    }
}
