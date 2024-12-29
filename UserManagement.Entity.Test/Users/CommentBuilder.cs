using CommentManagement.Entity.Comments;

namespace CommentManagement.Entity.Test.Users
{
    public class CommentBuilder
    {
        private string _contnent = Guid.NewGuid().ToString();
        private int _userId = new Random().Next(1, int.MaxValue);

        public CommentBuilder WithContent(string contnent)
        {
            _contnent = contnent;
            return this;
        }
        public CommentBuilder WithUserId(int userId)
        {
            _userId = userId;
            return this;
        }
        public Comment Build()
        {
            return new Comment(_userId, _contnent);
        }

    }
}
