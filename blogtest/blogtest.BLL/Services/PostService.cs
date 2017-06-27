using blogtest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using blogtest.DAL.Repositories;
using AutoMapper;

using System.Threading.Tasks;
using blogtest.Entities.Entities;
using blogtest.DAL.Interfaces;

namespace blogtest.BLL.Services
{
    public class PostService:  IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService( IPostRepository postRepository ) 
        {
            _postRepository = postRepository;
        }             

        public IEnumerable<Post> GetAll()
        {            
            return _postRepository.Get();
            
        }

        public Post GetById(string id)
        {
            var res = _postRepository.GetByID(id);
            _postRepository.Save();
            return res;
        }

        public void Add(Post entity)
        {
            _postRepository.Insert(entity);
            _postRepository.Save();
        }

        public void Update(Post entity)
        {
            _postRepository.Update(entity);
            _postRepository.Save();
        }

        public void Remove(string id)
        {
            _postRepository.Delete(id);
            _postRepository.Save();
        }
       
    }
}
