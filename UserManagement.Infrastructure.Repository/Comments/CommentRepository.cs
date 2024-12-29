using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Entity.Comments;
using CommentManagement.Infrastructure.Repository.Commons;
using CommentManagement.Infrastructure.Repository.DbContexts;

namespace CommentManagement.Infrastructure.Repository.Comments
{
    public class CommentRepository(CommentManagementDbContext dbContext) :
        BaseRepository<Comment, int>(dbContext), ICommentRepository
    {
        public async Task DeleteAsync(int id)
        {
            dbContext.Remove(id);

            await dbContext.SaveChangesAsync();
        }

        public IQueryable<Comment> GetAll()
        {
            return dbContext
                .Comments
                .AsQueryable();
        }
    }
}
