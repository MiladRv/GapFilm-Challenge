using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Application.Users.Contracts;
using CommentManagement.Entity.Comments;
using CommentManagement.Entity.Exceptions;
using CommentManagement.Entity.Users;

namespace CommentManagement.Application.Comments
{
    public sealed class CommentApplication(IUserRepository userRepository,
        ICommentRepository commentRepository)
        : ICommentApplication
    {
        public async Task<CommentOutputDto> CreateAsync(int userId,
            string content,
            CancellationToken cancellationToken = default)
        {
            User? user = await FindAndValidateUserAsync(userId);

            var comment = new Comment(user.Id, content);

            await commentRepository.AddAsync(comment);

            return comment.ToOutputDto();
        }


        public async Task ApproveAsync(int commentId)
        {
            var comment = await FindAndValidateCommentAsync(commentId);

            comment.Approve();

            await commentRepository.UpdateAsync(comment);
        }

        public (uint totalRecords, IEnumerable<CommentOutputDto> records) GetApprovedComments(
            ushort pageIndex,
            ushort pageSize,
            string? search = null)
        {
            var query = (commentRepository.GetAll() ?? Enumerable.Empty<Comment>())
                .Where(c => c.IsApproved);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(c => c.Content.Contains(search));

            if (!query.Any())
                return (0, Enumerable.Empty<CommentOutputDto>());

            return ((uint)query.Count(),
                query
                .OrderByDescending(c => c.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(c => c.ToOutputDto())
                .AsEnumerable());
        }

        public async Task RemoveAsync(int commentId)
        {

            var comment = await commentRepository.FindByIdAsync(commentId);

            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            // it coult be soft delete
            await commentRepository.DeleteAsync(comment.Id);
        }

        private async Task<Comment> FindAndValidateCommentAsync(int commentId)
        {
            var comment = await commentRepository.FindByIdAsync(commentId);

            // this could be custome exception
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            return comment;
        }

        private async Task<User?> FindAndValidateUserAsync(int userId)
        {
            var user = await userRepository.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException<User>(userId);

            return user;
        }
    }
}
