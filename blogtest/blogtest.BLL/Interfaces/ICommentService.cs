using blogtest.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllAsync(int postId);
        void Create(CommentDto ent);
        Task AddAsync(CommentDto entity);
        CommentDto Update(CommentDto entity);
    }
}
