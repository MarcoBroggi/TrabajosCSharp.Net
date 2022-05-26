using System;
using System.Runtime.Serialization;

namespace Base
{
    [Serializable]
    internal class ArchivosException : Exception
    {
        public ArchivosException()
        {
        }

        public ArchivosException(string message) : base(message)
        {
        }

        public ArchivosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArchivosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}