using System.ComponentModel.DataAnnotations;

namespace CommentManagement.Api.Contracts.Users
{
    public sealed record CreateUserCommand
    {

        [Required]
        [EmailAddress]
        public required string Email { get; init; }
    }
}
