using System.Runtime.Serialization;

namespace MartinMatta_MerlinCore.Actors
{
    [Serializable]
    internal class FullInventoryException : Exception
    {
        public FullInventoryException() : base()
        {
        }

        public FullInventoryException(string? message) : base(message)
        {
        }

        public FullInventoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FullInventoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}