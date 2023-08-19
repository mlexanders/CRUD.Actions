using Common.Base;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Actions.Server
{
    public class MongoRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        protected readonly IMongoCollection<TEntity> collection;

        public MongoRepository(IMongoDatabase db)
        {
            collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task Create(TEntity[] entities)
        {
            await collection.InsertManyAsync(entities);
        }

        public async Task Delete(TKey key)
        {
            var filter = Builders<TEntity>.Filter.Eq(r => r.Id, key);
            collection.DeleteOne(filter);
        }

        public async Task<TEntity[]> Read(Func<TEntity, bool> query = null, Expression<Func<TEntity, object>> include = null)
        {
            if (query == null) return collection.AsQueryable().ToArray();
            return collection.AsQueryable()
                .Where(query).ToArray();
        }

        public async Task<TEntity> ReadFirst(Expression<Func<TEntity, bool>> query = null)
        {
            return collection.AsQueryable()
                .Where(query).FirstOrDefault()!;
        }

        public async Task Update(TEntity entity)
        {
            var oldEntity = await ReadFirst(e => e.Id!.Equals(entity.Id));

            var filter = Builders<TEntity>.Filter
                .Eq(e => e.Id, oldEntity.Id);

            await collection.ReplaceOneAsync(filter, entity);
        }
    }
}
