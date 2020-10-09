using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class NaturalPersonEntity : Entity
    {
        public string SocialNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public IEnumerable<PurchaseEntity> Purchases { get; set; }
    }
}