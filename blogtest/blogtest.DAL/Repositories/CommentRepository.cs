using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using blogtest.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using blogtest.Entities.Entities;

namespace blogtest.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly BlogDbContext _entitiesContext;

        public CommentRepository(IServiceProvider serviceProvider)
        {
            //_entitiesContext = (IEntitiesContext)entitiesContext;
            _entitiesContext = (BlogDbContext)serviceProvider.GetService(typeof(IEntitiesContext));
        }

        public void Create(Comment ent)
        {

            //Post pp = new Post
            //{
            //    CreateDate = System.DateTime.Now,
            //    Description = "fsdfs",
            //    NamePost = "111111"
            //};
            //_entitiesContext.Posts.Add(pp);
            //_entitiesContext.SaveChanges();

            //Comment cc = new Comment
            //{
            //    CreateDate = System.DateTime.Now,
            //    TextComment = "dfsd",
            //    Post = pp
            //};

            //_entitiesContext.Comments.Add(cc);
            //_entitiesContext.SaveChanges();

            
            _entitiesContext.Comments.Add(ent);
            _entitiesContext.SaveChanges();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int postId)
        {
            var list = await _entitiesContext.Comments.Where(p => p.Post.Id == postId).ToListAsync();

            return list;
        }

        public void Save()
        {
            _entitiesContext.SaveChanges();
        }

        public async Task AddAsync(Comment entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Unable to add a null entity to the repository.");

            await _entitiesContext.Comments.AddAsync(entity);
            _entitiesContext.SaveChanges();
        }

        public Comment Update(Comment entity)
        {
            return _entitiesContext.Comments.Update(entity).Entity;
        }


    }
}
