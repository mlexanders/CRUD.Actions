using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.Actions.Implementation
{
    public class BaseCrudRepository<TEntity, Key> : ICrudRepository<TEntity, Key> where TEntity : Entity<Key>
    {

        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public BaseCrudRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await Create(new[] { entity });
        }

        public async Task Create(TEntity[] entity)
        {
            await dbSet.AddRangeAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity[]> Read(Func<TEntity, bool> query = null!, Expression<Func<TEntity, object>> include = null!)
        {
            if (query == null)
                return include is null ? await dbSet.AsNoTracking().ToArrayAsync() : dbSet.AsNoTracking().Include(include).ToArray();
            else
                return include is null ? dbSet.AsNoTracking().Where(query).ToArray() : dbSet.AsNoTracking().Include(include).Where(query).ToArray();
        }

        public async Task<TEntity> ReadFirst(Expression<Func<TEntity, bool>> query)
        {
            return await dbSet.FirstOrDefaultAsync(query);
        }

        public async Task Update(TEntity entity)
        {
            //var modifiedEntity = await dbSet.FirstOrDefaultAsync(e => e.GetPrimaryKey().Equals(entity.GetPrimaryKey()))
            //    ?? throw new NotFoundEntity(entity);

            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
