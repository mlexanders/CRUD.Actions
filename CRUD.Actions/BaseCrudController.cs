using CRUD.Actions.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Actions
{
    [Route("/api/[controller]")]
    [ApiController]
    public abstract class BaseCrudController<TEntity, TKey> : Controller where TEntity : Entity<TKey>
    {
        private readonly BaseCrudRepository<TEntity, TKey> repository;

        public BaseCrudController(BaseCrudRepository<TEntity, TKey> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public virtual async Task Create([FromBody] TEntity entity)
        {
            await repository.Create(entity);
        }
    }
}
