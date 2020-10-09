using System;

namespace _6MKT.BackOffice.Domain.Clock
{
    public class Clock : IClock
    {
        public DateTimeOffset GetUtcNow() =>
            DateTimeOffset.Now;
    }
}