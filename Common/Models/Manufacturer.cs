using CRUD.Actions;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Manufacturer : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
