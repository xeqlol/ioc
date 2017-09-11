using System;

namespace IoC
{
    class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException() { }
        public TypeNotRegisteredException(string message) : base(message) { }
        public TypeNotRegisteredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
