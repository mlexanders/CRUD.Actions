﻿using Actions.Common.Base;
using Microsoft.AspNetCore.Mvc;

namespace Actions.Server
{
    [Route("/api/[controller]")]
    [ApiController]
    public abstract class CrudController<TEntity, TKey> : Controller, ICrud<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly ICrudRepository<TEntity, TKey> repository;

        public CrudController(ICrudRepository<TEntity, TKey> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public virtual async Task Create([FromBody] TEntity entity)
        {
            await repository.Create(entity);
        }

        [HttpPost("/api/[controller]/many")]
        public virtual async Task Create([FromBody] List<TEntity> entities)
        {
            await repository.Create(entities.ToArray());
        }

        [HttpDelete]
        public virtual async Task Delete(TKey key)
        {
            await repository.Delete(key);
        }

        [HttpGet("/api/[controller]/all")]
        public virtual Task<TEntity[]> Read()
        {
            return repository.Read();
        }

        [HttpGet("{key}")]
        public virtual async Task<TEntity> ReadFirst(TKey key)
        {
            return await repository.ReadFirst(e => e.Id!.Equals(key));
        }

        [HttpPatch]
        public virtual async Task Update([FromBody] TEntity entity)
        {
            await repository.Update(entity);
        }
    }
}
