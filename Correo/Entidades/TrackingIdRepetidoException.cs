using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    internal class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException()
        {
        }

        public TrackingIdRepetidoException(string message) : base(message)
        {
        }

        public TrackingIdRepetidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TrackingIdRepetidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}