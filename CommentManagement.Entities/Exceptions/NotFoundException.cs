namespace CommentManagement.Entity.Exceptions
{
    public sealed class NotFoundException<T> : NotFoundException
    {
        public NotFoundException(dynamic id)
        {
            Message = $"{typeof(T).Name} not found with this id {id}";
        }

        public NotFoundException()
        {
            Message = $"{typeof(T).Name} not found";
        }
    }

    public class NotFoundException : CustomException;
}
