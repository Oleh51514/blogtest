using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using blogtest.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using blogtest.Entities.Entities;
using blogtest.DAL.Interfaces;

namespace blogtest.DAL.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(
            IServiceProvider serviceProvider,
            BlogDbContext context
        ) : base(context)
        {
            //_entitiesContext = (IEntitiesContext)entitiesContext;
            //_entitiesContext = (BlogDbContext)serviceProvider.GetService(typeof(IEntitiesContext));
        }
    }
}
