using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.DAL2.Entities
{
    class ApplicationContext : DbContext , IEntitiesContext2
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
    public class Post
    {
        public int Id { get; set; }
        public string NamePost { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }


        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }

        public string TextComment { get; set; }
        public DateTime DateTime { get; set; }

        //public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
