using Common;

namespace Template
{

    public class Test
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
    public class User : Entity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override int GetPrimaryKey()
        {
            return Id;
        }
    }

    public class Car2 : Entity<long>
    {
        public long Id { get; set; }
        public string? Tittle { get; set; }

        public override long GetPrimaryKey()
        {
            return Id;
        }
    }
}
