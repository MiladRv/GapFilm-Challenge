using CommentManagement.Application.Commons;

namespace CommentManagement.Application.Users.Contracts
{
    public sealed record UserOutputDto : BaseOutputDto<int>
    {
        public string Email { get; init; } = null!;
        public DateTime CreatedAt { get; init; }
    }
}
