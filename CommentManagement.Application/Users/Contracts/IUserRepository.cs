using CommentManagement.Application.Commons;
using CommentManagement.Entity.Users;

namespace CommentManagement.Application.Users.Contracts
{
    public interface IUserRepository : IBaseRepository<User,int>
    {
        User? FindByEmail(string email);
    }
}
