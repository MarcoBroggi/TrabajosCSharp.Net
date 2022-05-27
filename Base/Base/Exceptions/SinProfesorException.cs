using System;
using System.Runtime.Serialization;

namespace Base
{
    [Serializable]
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
        {
        }

        public SinProfesorException(string message) : base(message)
        {
        }

        public SinProfesorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SinProfesorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}