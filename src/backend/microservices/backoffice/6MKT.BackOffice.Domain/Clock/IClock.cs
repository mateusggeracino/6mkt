using System;

namespace _6MKT.BackOffice.Domain.Clock
{
    public interface IClock
    {
        DateTimeOffset GetUtcNow();
    }
}