
using blogtest.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post GetById(string id);
        void Add(Post entity);
        void Update(Post entity);
        void Remove(string id);
    }
}
