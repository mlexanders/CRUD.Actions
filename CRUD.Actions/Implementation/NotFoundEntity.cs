using System.Runtime.Serialization;

namespace CRUD.Actions.Implementation
{
    [Serializable]
    internal class NotFoundEntity : Exception
    {
        private object entity;

        public NotFoundEntity()
        {
        }

        public NotFoundEntity(object entity)
        {
            this.entity = entity;
        }

        public NotFoundEntity(string? message) : base(message)
        {
        }

        public NotFoundEntity(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundEntity(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}