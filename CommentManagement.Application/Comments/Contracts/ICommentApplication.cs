namespace CommentManagement.Application.Comments.Contracts
{
    public interface ICommentApplication
    {
        Task<CommentOutputDto> CreateAsync(int userId, string content,
            CancellationToken cancellationToken = default);
        Task ApproveAsync(int commentId);
        (uint totalRecords, IEnumerable<CommentOutputDto> records) GetApprovedComments(
            ushort pageIndex,
            ushort pageSize,
            string? search = null);
        Task RemoveAsync(int commentId);
    }
}
