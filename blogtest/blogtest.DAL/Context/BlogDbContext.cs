using blogtest.DAL.Entities;
using blogtest.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.DAL.Context
{
    public class BlogDbContext : DbContext, IEntitiesContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //public BlogDbContext()
        //{

        //}
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }


    }
}
