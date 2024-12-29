using CommentManagement.Application.Users.Contracts;
using CommentManagement.Entity.Users;
using CommentManagement.Infrastructure.Repository.Commons;
using CommentManagement.Infrastructure.Repository.DbContexts;

namespace CommentManagement.Infrastructure.Repository.Users
{
    public sealed class UserRepository(CommentManagementDbContext dbContext) 
        : BaseRepository<User, int>(dbContext), IUserRepository
    {
        public User? FindByEmail(string email)
        {
            return dbContext
                .Users?
                .FirstOrDefault(u => u.Email.Equals(email,StringComparison.OrdinalIgnoreCase));
        }
    }
}
