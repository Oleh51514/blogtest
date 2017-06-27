
using blogtest.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllAsync(int postId);
        void Create(Comment ent);
        Task AddAsync(Comment entity);
        Comment Update(Comment entity);
    }
}
