using blogtest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.DAL.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetById(int id);
        Task AddAsync(Post entity);
        Post Update(Post entity);
        void Remove(int id);
    }
}
