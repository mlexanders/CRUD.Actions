namespace Common
{
    public abstract class Entity<TKey>
    {
        public abstract TKey GetPrimaryKey();
    }
}