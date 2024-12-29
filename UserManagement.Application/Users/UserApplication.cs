using CommentManagement.Application.Users.Contracts;
using CommentManagement.Entity.Exceptions;
using CommentManagement.Entity.Users;

namespace CommentManagement.Application.Users
{
    public sealed class UserApplication(IUserRepository userRepository)
        : IUserApplication
    {
        public async Task<UserOutputDto> CreateAsync(string email)
        {
            var user = userRepository.FindByEmail(email);

            // this could be custome exception
            if (user is not null)
                throw new Exception($"there is any user with this email {email}");

            user = new User(email);

            await userRepository.AddAsync(user);


            return user.ToOutputDto();
        }

        public async Task<UserOutputDto> FindByIdAsync(int id)
        {
            var user = await userRepository.FindByIdAsync(id);

            // this could be custome exception
            if (user is null)
                throw new NotFoundException<User>(id);

            return user.ToOutputDto();
        }
    }
}
