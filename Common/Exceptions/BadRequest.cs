using System.Runtime.Serialization;

namespace Actions.Common.Exceptions
{
    [Serializable]
    public class BadRequest : Exception
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