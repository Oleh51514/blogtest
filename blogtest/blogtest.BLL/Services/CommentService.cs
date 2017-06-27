using AutoMapper;
using blogtest.BLL.Interfaces;
using blogtest.DAL.Repositories;
using blogtest.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace blogtest.BLL.Services
{
    public class CommentService :  ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService( ICommentRepository commentRepository ) 
        {
            _commentRepository = commentRepository;
        }

        public void Create(Comment ent)
        {        
            _commentRepository.Create(ent);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int postId)
        {
            var res = await _commentRepository.GetAllAsync(postId);
            return res;
            
        }

        public async Task AddAsync(Comment entity)
        {
            await _commentRepository.AddAsync(entity);
        }

        public Comment Update(Comment entity)
        {
            
            var commentDto = Mapper.Map<Comment, Comment>(_commentRepository.Update(entity));
            return commentDto;
        }
    }
}
