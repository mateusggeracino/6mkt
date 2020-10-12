using System;

namespace _6MKT.Common.Clock
{
    public interface IClock
    {
        DateTimeOffset GetUtcNow();
    }
}