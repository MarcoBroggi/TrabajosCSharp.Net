using System;
using System.Runtime.Serialization;

namespace Base
{
    [Serializable]
    internal class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
        }

        public NacionalidadInvalidaException(string message) : base(message)
        {
        }

        public NacionalidadInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NacionalidadInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}