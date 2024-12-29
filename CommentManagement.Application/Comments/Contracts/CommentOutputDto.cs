using CommentManagement.Application.Commons;

namespace CommentManagement.Application.Comments.Contracts
{
    public sealed record CommentOutputDto : BaseOutputDto<int>
    {
        public string Content { get; init; } = null!;
        public bool IsApproved { get; init; } = false;
        public int UserId { get; internal set; }
    }
}