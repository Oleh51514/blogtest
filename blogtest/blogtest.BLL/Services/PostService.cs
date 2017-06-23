using blogtest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using blogtest.Common.Dtos;
using blogtest.DAL.Repositories;
using AutoMapper;
using blogtest.DAL.Entities;
using System.Threading.Tasks;

namespace blogtest.BLL.Services
{
    public class PostService: BaseService, IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(
            IMapper mapper,
            IPostRepository postRepository
        ) : base(mapper)
        {
            _postRepository = postRepository;
        }             

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {            
            var rez = await _postRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(rez);
        }

        public async Task<PostDto> GetById(int id)
        {
            var rez = await _postRepository.GetById(id);
            return Mapper.Map<Post, PostDto>(rez);
        }

        public async Task AddAsync(PostDto entity)
        {
            var post = Mapper.Map<PostDto, Post>(entity);
            await _postRepository.AddAsync(post);
        }

        public PostDto Update(PostDto entity)
        {
            var post = Mapper.Map<PostDto, Post>(entity);
            var postDto = Mapper.Map<Post, PostDto>(_postRepository.Update(post));
            return postDto;
        }

        public void Remove(int id)
        {
            _postRepository.Remove(id);
        }
       
    }
}
