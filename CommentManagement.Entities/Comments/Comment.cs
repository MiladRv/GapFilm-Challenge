namespace CommentManagement.Entity.Comments
{
    public sealed class Comment : BaseEntity<int>
    {
        public Comment(int userId,
            string content)
        {
            if (string.IsNullOrWhiteSpace(content) ||
                content.Length > 1000)
                throw new ArgumentException(nameof(content));

            UserId = userId;
            Content = content;
        }

        public int UserId { get; private set; }
        public string Content { get; private set; }
        public bool IsApproved { get; private set; } = false;


        public void Approve()
        {
            IsApproved = true;
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
