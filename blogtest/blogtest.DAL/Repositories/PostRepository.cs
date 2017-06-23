using blogtest.DAL.Context;
using blogtest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _entitiesContext;

        public PostRepository(IServiceProvider serviceProvider)
        {

            //_entitiesContext = (IEntitiesContext)entitiesContext;
            _entitiesContext = (BlogDbContext)serviceProvider.GetService(typeof(IEntitiesContext));
        }
        
        public async Task<IEnumerable<Post>> GetAllAsync()
        {            
            return await _entitiesContext.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _entitiesContext.Posts.Where(c => c.PostId == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Post entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Unable to add a null entity to the repository.");

            await _entitiesContext.Posts.AddAsync(entity);
            _entitiesContext.SaveChanges();
        }

        public Post Update(Post entity)
        {
            entity = _entitiesContext.Posts.Update(entity).Entity;
            _entitiesContext.SaveChanges();
            return entity;
        }

        public void Remove(int id)
        {
            var entity = new Post() { PostId = id };
            this.Remove(entity);
        }

        private void Remove(Post entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Unable to delete a null entity to the repository.");
            _entitiesContext.Posts.Attach(entity);
            _entitiesContext.Entry(entity).State = EntityState.Deleted;
            _entitiesContext.Remove(entity);
            _entitiesContext.SaveChanges();
        }


        //public Foo GetSingle(int fooId)
        //{
        //    var query = this.GetAll().FirstOrDefault(x => x.FooId == fooId);
        //    return query;
        //}

        //public void Add(Foo entity)
        //{
        //    context.Foos.Add(entity);
        //}

        //public void Delete(Foo entity)
        //{
        //    context.Foos.Remove(entity);
        //}

        //public void Edit(Foo entity)
        //{
        //    context.Entry<Foo>(entity).State = System.Data.EntityState.Modified;
        //}

        //public void Save()
        //{

        //    context.SaveChanges();
        //}
    }
}

