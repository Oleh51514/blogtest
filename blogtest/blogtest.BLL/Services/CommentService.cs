using blogtest.BLL.Interfaces;
using blogtest.DAL.Interfaces;
using blogtest.Entities.Entities;
using storagecore.Abstractions.Uow;
using System.Collections.Generic;
using System.Linq;

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

                entity.Post = postRepository.Get(postId);
                repository.Add(entity);

                uow.SaveChanges();
            }
        }

        public IEnumerable<Comment> GetAllByPostId(string postId)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<ICommentRepository>();
                return repository.Query(
                    s => s.Post.Id == postId,
                    o => o.OrderByDescending(f => f.CreationDate));
            }
        }
    }
}
