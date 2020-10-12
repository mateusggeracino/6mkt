using System;

namespace _6MKT.Common.Clock
{
    public class Clock : IClock
    {
        public DateTimeOffset GetUtcNow() =>
            DateTimeOffset.Now;
    }
}