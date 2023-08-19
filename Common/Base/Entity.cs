using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Base
{
    public abstract class Entity<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; } = default!;
    }
}