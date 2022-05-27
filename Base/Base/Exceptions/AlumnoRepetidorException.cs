using System;
using System.Runtime.Serialization;

namespace Base
{
    [Serializable]
    public class AlumnoRepetidorException : Exception
    {
        public AlumnoRepetidorException()
        {
        }

        public AlumnoRepetidorException(string message) : base(message)
        {
        }

        public AlumnoRepetidorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlumnoRepetidorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}