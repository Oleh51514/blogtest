
using blogtest.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllByPostId(string postId);
        void Create(Comment ent, string postId);
    }
}
