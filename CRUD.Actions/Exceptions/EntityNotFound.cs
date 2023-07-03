using System.Runtime.Serialization;

namespace CRUD.Actions.Implementation
{
    [Serializable]
    internal class EntityNotFound : Exception
    {
        private Type type;

        public EntityNotFound()
        {
        }

        public EntityNotFound(Type type)
        {
            this.type = type;
        }

        public EntityNotFound(string? message) : base(message)
        {
        }

        public EntityNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}