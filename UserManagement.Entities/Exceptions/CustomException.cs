namespace CommentManagement.Entity.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
        {
            
        }
        public CustomException(string message)
        {
            Message = message;
        }

        public string Message { get; init; }
    }
}
