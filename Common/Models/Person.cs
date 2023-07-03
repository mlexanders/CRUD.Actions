using CRUD.Actions;

namespace Common.Models
{
    public class Person : Entity<long>
    {
        public string Name { get; set; }
        public float Rating { get; set; }
    }
}
