using CommentManagement.Application.Commons;
using CommentManagement.Entity.Comments;

namespace CommentManagement.Application.Comments.Contracts
{
    public interface ICommentRepository : IBaseRepository<Comment, int>
    {
        Task DeleteAsync(int id);
        IQueryable<Comment>? GetAll();
    }
}
