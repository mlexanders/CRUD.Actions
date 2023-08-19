using Common.Base;
using Common.Exceptions;
using System.Net.Http.Json;

namespace Actions.Client
{
    public class BaseCrudRequests<TEntity, TKey> : ICrud<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly HttpClient client;
        private readonly string path;

        public BaseCrudRequests(HttpClient client, string path)
        {
            this.client = client;
            this.path = path;
        }

        public Task Create(TEntity entity)
        {
            return Create(new List<TEntity>() { entity });
        }

        public async Task Create(List<TEntity> entities)
        {
            var response = await client.PostAsJsonAsync(path, entities) ?? throw new NotImplementedException();
            if (!response.IsSuccessStatusCode) throw new BadRequest(response.RequestMessage?.ToString());
        }

        public async Task Delete(TKey key)
        {
            var response = await client.DeleteAsync(path + $"/{key}") ?? throw new NotImplementedException();
            if (!response.IsSuccessStatusCode) throw new BadRequest(response.RequestMessage?.ToString());
        }

        public async Task<TEntity[]> Read()
        {
            var response = await client.GetAsync(path) ?? throw new NotImplementedException();
            if (!response.IsSuccessStatusCode) throw new BadRequest(response.RequestMessage?.ToString());
            return await response.Content.ReadFromJsonAsync<TEntity[]>();
        }

        public async Task<TEntity> ReadFirst(TKey key)
        {
            var response = await client.GetAsync(path + $"/{key}") ?? throw new NotImplementedException();
            if (!response.IsSuccessStatusCode) throw new BadRequest(response.RequestMessage?.ToString());
            return await response.Content.ReadFromJsonAsync<TEntity>();
        }

        public async Task Update(TEntity entity)
        {
            var response = await client.PutAsJsonAsync(path, entity) ?? throw new NotImplementedException(); //TODO path/post ??? 
            if (!response.IsSuccessStatusCode) throw new BadRequest(response.RequestMessage?.ToString());
        }
    }
}
