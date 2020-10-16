using System;

namespace _6MKT.BackOffice.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
            
        }

        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}