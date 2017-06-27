using AutoMapper;
using blogtest.BLL.Interfaces;
using blogtest.DAL.Interfaces;
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
            _commentRepository.Insert(ent);
            _commentRepository.Save();
        }

        public IEnumerable<Comment> GetByPostId(string postId)
        {
            var res = _commentRepository.Get(c => c.Post.Id == postId);
            return res;
            
        }
    }
}
