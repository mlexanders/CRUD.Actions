using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actions.Common.Base
{
    public abstract class Entity<TKey>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey? Id { get; set; }
    }
}