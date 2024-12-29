namespace CommentManagement.Api.Contracts.Results
{
    /// <summary>
    ///  failure result
    /// </summary>
    public sealed record FailureResultDto : ResultDto
    {

        public FailureResultDto(string message,
            ushort status)
        {
            Message = message;
            Status = status; 
        }

        public string Message { get; init; }

    }
}
