namespace CommentManagement.Application.Users.Contracts
{
    public interface IUserApplication
    {
        Task<UserOutputDto> CreateAsync(string email);
        Task<UserOutputDto> FindByIdAsync(int id);
    }
}
