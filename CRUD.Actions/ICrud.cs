namespace CRUD.Actions
{
    public interface ICrud<TEntity, TKey> where TEntity : Entity<TKey>
    {
        Task Create(TEntity entity);
        Task Create(List<TEntity> entities);
        Task<TEntity> ReadFirst(TKey key);
        Task<TEntity[]> Read();
        Task Update(TEntity entity);
        Task Delete(TKey key);
    }
}
