using System;
using System.Runtime.Serialization;

namespace TodoRepositoryLibrary
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() { }

        public DuplicateTodoItemException(string message) : base(message) { }

        public DuplicateTodoItemException(string message, Exception inner) : base(message, inner) { }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
