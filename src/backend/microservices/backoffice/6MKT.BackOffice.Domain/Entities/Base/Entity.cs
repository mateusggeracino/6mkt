using System;

namespace _6MKT.BackOffice.Domain.Entities.Base
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}