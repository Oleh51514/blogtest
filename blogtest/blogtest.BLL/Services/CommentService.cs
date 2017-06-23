using AutoMapper;
using blogtest.BLL.Interfaces;
using blogtest.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using blogtest.Common.Dtos;
using System.Threading.Tasks;
using blogtest.DAL.Entities;

namespace blogtest.BLL.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(
            IMapper mapper,
            ICommentRepository commentRepository
        ) : base(mapper)
        {
            _commentRepository = commentRepository;
        }

        public void Create(CommentDto entDto)
        {
            var ent = Mapper.Map<CommentDto, Comment>(entDto); ;
            _commentRepository.Create(ent);
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync(int postId)
        {
            var rez = await _commentRepository.GetAllAsync(postId);
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(rez); ;
        }

        public async Task AddAsync(CommentDto entity)
        {
            var post = Mapper.Map<CommentDto, Comment>(entity);
            await _commentRepository.AddAsync(post);
        }

        public CommentDto Update(CommentDto entity)
        {
            var comment = Mapper.Map<CommentDto, Comment>(entity);
            var commentDto = Mapper.Map<Comment, CommentDto>(_commentRepository.Update(comment));
            return commentDto;
        }
    }
}
