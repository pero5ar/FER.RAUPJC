﻿using System;

namespace Models
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() { }

        public DuplicateTodoItemException(string message) : base(message) { }

        public DuplicateTodoItemException(string message, Exception inner) : base(message, inner) { }
    }
}
