using blogtest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using blogtest.DAL.Repositories;
using AutoMapper;

using System.Threading.Tasks;
using blogtest.Entities.Entities;

namespace blogtest.BLL.Services
{
    public class PostService:  IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService( IPostRepository postRepository ) 
        {
            _postRepository = postRepository;
        }             

        public async Task<IEnumerable<Post>> GetAllAsync()
        {            
            return await _postRepository.GetAllAsync();
            
        }

        public async Task<Post> GetById(int id)
        {
            return await _postRepository.GetById(id);          
        }

        public async Task AddAsync(Post entity)
        {
            await _postRepository.AddAsync(entity);
        }

        public Post Update(Post entity)
        {
            return _postRepository.Update(entity);
        }

        public void Remove(int id)
        {
            _postRepository.Remove(id);
        }
       
    }
}
