using CommentManagement.Entity.Comments;

namespace CommentManagement.Application.Comments.Contracts
{
    internal static class CommentExtensions
    {
        public static CommentOutputDto ToOutputDto(this Comment comment)
        {
            return new CommentOutputDto()
            {
                Id = comment.Id,
                UserId = comment.UserId,
                Content = comment.Content,
                IsApproved = comment.IsApproved,
            };
        }
    }
}
