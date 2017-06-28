using blogtest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using blogtest.DAL.Repositories;
using AutoMapper;

using System.Threading.Tasks;
using blogtest.Entities.Entities;
using blogtest.DAL.Interfaces;
using storagecore.Abstractions.Uow;
using Microsoft.EntityFrameworkCore;

namespace blogtest.BLL.Services
{
    public class PostService:  IPostService
    {
        private readonly IUowProvider _uowProvider;

        public PostService(IUowProvider uowProvider) 
        {
            _uowProvider = uowProvider;
        }             

        public IEnumerable<Post> GetAll()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<IPostRepository>();
                return repository.GetAll();

            }

        }

        public Post GetById(string id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<IPostRepository>();
                return repository.Get(id, s => s.Include(c => c.Comment));

            }           
        }

        public void Add(Post entity)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<IPostRepository>();
                repository.Add(entity);
                uow.SaveChanges();
            }
        }

        public void Update(Post entity)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<IPostRepository>();
                repository.Update(entity);
                uow.SaveChanges();
            }
        }

        public void Remove(string id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<IPostRepository>();
                repository.Remove(id);
                uow.SaveChanges();
            }
        }
       
    }
}
