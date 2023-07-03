using System.Runtime.Serialization;

namespace CRUD.Actions.Implementation
{
    [Serializable]
    internal class BadRequest : Exception
    {
        public BadRequest()
        {
        }

        public BadRequest(string? message) : base(message)
        {
        }

        public BadRequest(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BadRequest(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}