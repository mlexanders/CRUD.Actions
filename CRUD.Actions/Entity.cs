using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Actions
{
    public abstract class Entity<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; } = default!;
    }
}