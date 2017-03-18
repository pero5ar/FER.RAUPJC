using System;
using System.Runtime.Serialization;

namespace TodoRepositoryLibrary
{
    public class TodoAccessDeniedException : Exception
    {
        public TodoAccessDeniedException() { }

        public TodoAccessDeniedException(string message) : base(message) { }

        public TodoAccessDeniedException(string message, Exception inner) : base(message, inner) { }

        protected TodoAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
