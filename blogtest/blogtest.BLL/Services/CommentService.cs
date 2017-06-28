using AutoMapper;
using blogtest.BLL.Interfaces;
using blogtest.DAL.Interfaces;
using blogtest.DAL.Repositories;
using blogtest.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using storagecore.Abstractions.Uow;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace blogtest.BLL.Services
{
    public class CommentService :  ICommentService
    {

        private readonly IUowProvider _uowProvider;

        public CommentService(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public void Create(Comment entity, string postId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<ICommentRepository>();
                var postRepository = uow.GetCustomRepository<IPostRepository>();
                var post = postRepository.Get(postId);
                entity.Post = post;
                repository.Update(entity);
                uow.SaveChanges();

            }
        }

        public IEnumerable<Comment> GetAllByPostId(string postId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<ICommentRepository>();
                return repository.Query(s => s.Post.Id == postId);

            }

        }
    }
}
