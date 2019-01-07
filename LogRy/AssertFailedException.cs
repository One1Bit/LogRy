using System;
using System.Runtime.Serialization;

namespace YourProject.Tests
{
    [Serializable]
    internal class AssertFailedException : Exception
    {
        public AssertFailedException()
        {
        }

        public AssertFailedException(string message) : base(message)
        {
        }

        public AssertFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AssertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}