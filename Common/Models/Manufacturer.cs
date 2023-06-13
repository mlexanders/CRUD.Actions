using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Manufacturer : Entity<Guid>
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override Guid GetPrimaryKey()
        {
            return Guid;
        }
    }
}
