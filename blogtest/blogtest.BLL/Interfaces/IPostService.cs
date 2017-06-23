using blogtest.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.BLL.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto> GetById(int id);
        Task AddAsync(PostDto entity);
        PostDto Update(PostDto entity);
        void Remove(int id);
    }
}
