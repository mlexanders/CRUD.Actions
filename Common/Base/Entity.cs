using System.ComponentModel.DataAnnotations.Schema;

namespace Actions.Common.Base;

public abstract class Entity<TKey>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey? Id { get; set; }
}