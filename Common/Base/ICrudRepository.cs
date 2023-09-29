using System.Linq.Expressions;

namespace Actions.Common.Base
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        Task Create(TEntity entity);
        Task Create(TEntity[] entity);
        Task<TEntity[]> Read(Func<TEntity, bool> query = null!, Expression<Func<TEntity, object>> include = null!);
        Task<TEntity> ReadFirst(Expression<Func<TEntity, bool>> query = null!);
        Task Update(TEntity entity);
        Task Delete(TKey key);
    }
}
