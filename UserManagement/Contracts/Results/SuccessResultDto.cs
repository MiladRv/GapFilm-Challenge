namespace CommentManagement.Api.Contracts.Results
{
    /// <summary>
    /// success result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed record SuccessResultDto<T> : ResultDto where T : class
    {
        public T Result { get; private init; }

        public SuccessResultDto(T result)
        {
            Result = result;
        }
    }
}
