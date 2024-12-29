namespace CommentManagement.Entity
{
    public abstract class BaseEntity<TKey> : BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public TKey Id { get; init; }
        public DateTime CreatedAt { get; private init; }

    }

    public abstract class BaseEntity
    {

    }
}
