using System;

namespace _6MKT.BackOffice.Domain.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException()
        {
            
        }

        public ConflictException(string message) : base(message)
        {
            
        }
    }
}