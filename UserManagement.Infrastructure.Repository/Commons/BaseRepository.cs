using CommentManagement.Application.Commons;
using CommentManagement.Entity;
using CommentManagement.Infrastructure.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.Repository.Commons
{
    public abstract class BaseRepository<T, TKey>(DbContext dbContext)
        : IBaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        public async Task<T> AddAsync(T entity)
        {
            await dbContext.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> FindByIdAsync(TKey id)
        {
            return await dbContext.FindAsync<T>(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Update(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
