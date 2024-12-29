using System.Net.Mail;
using CommentManagement.Entity.Comments;

namespace CommentManagement.Entity.Users
{
    public sealed class User : BaseEntity<int>
    {
        public User()
        {

        }
        public User(string email)
        {
            if (!MailAddress.TryCreate(email, out _))
                throw new ArgumentException(nameof(email));

            Email = email;
        }

        public string Email { get; init; }
        public List<Comment> Comments { get; private set; }

        public Comment AddComment(string content)
        {
            var comment = new Comment(Id, content);

            Comments ??= new List<Comment>();
            Comments.Add(comment);

            return comment;
        }

        public void ApproveComment(int commentId)
        {
            var comment = Comments.FirstOrDefault(c => c.Id.Equals(commentId));

            if (comment is null)
                throw new ArgumentException(nameof(comment));

            comment.Approve();
        }

    }

}
