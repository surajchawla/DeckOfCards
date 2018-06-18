using System;

namespace CardGame
{
    public class EmptyDeckException : Exception
    {
        public EmptyDeckException()
        {
        }

        public EmptyDeckException(string message) : base(message)
        {
        }

        public EmptyDeckException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}