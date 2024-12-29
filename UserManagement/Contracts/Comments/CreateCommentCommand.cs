using System.ComponentModel.DataAnnotations;

namespace CommentManagement.Api.Contracts.Comments
{
    public sealed record CreateCommentCommand
    {
        /// <summary>
        /// content of comment, it's mandator and maximum length is 1000
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public required string Content { get; init; }

        /// <summary>
        /// userId
        /// </summary>
        [Required]
        public required int UserId { get; init; }
    }
}
