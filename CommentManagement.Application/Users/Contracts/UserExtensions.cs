using CommentManagement.Entity.Users;

namespace CommentManagement.Application.Users.Contracts
{
    internal static class UserExtensions
    {
        public static UserOutputDto ToOutputDto(this User user)
        {
            return new UserOutputDto()
            {
                Id = user.Id,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
