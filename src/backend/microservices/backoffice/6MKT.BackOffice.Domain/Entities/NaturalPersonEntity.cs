using _6MKT.BackOffice.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class NaturalPersonEntity : Entity
    {
        public Guid IdentityId { get; set; }
        public string Email { get; set; }
        public string SocialNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public long AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public IEnumerable<PurchaseEntity> Purchases { get; set; }

        public void SetIdentityId(string id) => IdentityId = Guid.Parse(id);
    }
}