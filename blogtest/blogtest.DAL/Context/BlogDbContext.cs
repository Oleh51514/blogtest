
using blogtest.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using storagecore.Abstractions.Context;

namespace blogtest.DAL.Context
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>, IEntityContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }       

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .Map(t => t.MapLeftKey("CourseId")
        //        .MapRightKey("StudentId")
        //        .ToTable("CourseStudent"));
        //}


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .Map(t => t.MapLeftKey("CourseId")
        //        .MapRightKey("StudentId")
        //        .ToTable("CourseStudent"));
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<DataEventRecord>().HasKey(m => m.Id);
        //    base.OnModelCreating(builder);
        //}

    }
}
