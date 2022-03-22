using System.Runtime.Serialization;

namespace GoatFarm.Management.API.GoatManagement.CommandHandlers
{
    [Serializable]
    internal class TagNumberNotAvailableException : Exception
    {
        public TagNumberNotAvailableException(Domain.GoatManagement.TagNumber id)
        {
        }

        public TagNumberNotAvailableException(string? message) : base(message)
        {
        }

        public TagNumberNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TagNumberNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}