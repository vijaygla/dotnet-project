using System;

namespace BookBuddy
{
    internal class InvalidBookFormatException : Exception
    {
        public InvalidBookFormatException(string message) : base(message)
        {
        }
    }
}

