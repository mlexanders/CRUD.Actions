namespace Common.Models
{
    public class Person : Entity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }

        public override long GetPrimaryKey()
        {
            return Id;
        }
    }
}
