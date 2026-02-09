using System;

namespace SCMS.Common.Exceptions
{
    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException(string message) : base(message) { }
    }
}
