using System;

namespace _6MKT.BackOffice.Domain.Entities.Base
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public long? CreatedId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public long? ModifiedId { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}