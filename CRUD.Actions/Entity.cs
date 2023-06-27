namespace CRUD.Actions
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; } = default!;
    }
}