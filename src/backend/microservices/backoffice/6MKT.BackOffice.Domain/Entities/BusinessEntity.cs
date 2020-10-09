using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class BusinessEntity : Entity
    {
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }

        public IEnumerable<OfferEntity> Offers { get; set; }
    }
}