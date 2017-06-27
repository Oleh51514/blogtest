using blogtest.DAL.Context;
using blogtest.DAL.Interfaces;
using blogtest.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.DAL.Repositories
{
    public class PostRepository: BaseRepository<Post>, IPostRepository
    {
        public PostRepository(
            IServiceProvider serviceProvider,
            BlogDbContext context
        ) : base(context)
        {
            //_entitiesContext = (BlogDbContext)serviceProvider.GetService(typeof(IEntitiesContext));
        }

    }
}

