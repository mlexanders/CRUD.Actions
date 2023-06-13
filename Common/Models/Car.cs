using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Car : Entity<string>
    {
        [Key]
        public string VINCode { get; set; }
        public string Name { get; set; }
        public Guid ManufacturerGuid { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }

        public override string GetPrimaryKey()
        {
            return VINCode;
        }
    }
}
