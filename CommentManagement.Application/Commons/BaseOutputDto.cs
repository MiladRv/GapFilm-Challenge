namespace CommentManagement.Application.Commons
{
    public abstract record BaseOutputDto<TKey>
    {
        public required TKey Id { get; init; }
    }
}
