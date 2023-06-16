namespace CRUD.Actions
{
    public abstract class Entity<TKey>
    {
        public abstract TKey GetPrimaryKey();
    }
}