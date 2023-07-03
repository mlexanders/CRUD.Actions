using CRUD.Actions;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Car : Entity<string>
    {
        public string Name { get; set; }
        public Guid ManufacturerGuid { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
