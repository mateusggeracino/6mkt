using System;
using _6MKT.BackOffice.Domain.Entities.Base;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class BusinessEntity : Entity
    {
        public Guid IdentityId { get; set; }
        public string Email { get; set; }
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }

        public IEnumerable<OfferEntity> Offers { get; set; }

        public void SetIdentityId(string id) => IdentityId = Guid.Parse(id);
    }
}