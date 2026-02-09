using System;

namespace SCMS.Common.Exceptions
{
    public class UnderageException : Exception
    {
        public UnderageException(string message) : base(message) { }
    }
}
