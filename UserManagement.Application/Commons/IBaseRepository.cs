using CommentManagement.Entity;

namespace CommentManagement.Application.Commons
{
    public interface IBaseRepository<T, in TKey> where T : BaseEntity<TKey>
    {
        Task<T> AddAsync(T entity);
        Task<T?> FindByIdAsync(TKey id);
        Task<T> UpdateAsync(T entity);
    }
}
