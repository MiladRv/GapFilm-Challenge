using CommentManagement.Entity.Comments;
using CommentManagement.Entity.Users;
using CommentManagement.Infrastructure.Repository.Comments;
using CommentManagement.Infrastructure.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.Repository.DbContexts
{
    public class CommentManagementDbContext : DbContext
    {
        public CommentManagementDbContext(DbContextOptions<CommentManagementDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
