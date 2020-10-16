﻿using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class OfferEntity : Entity
    {
        public string Description { get; set; }
        public bool InStock { get; set; }
        public double Price { get; set; }
        public bool Selected { get; set; }

        public long PurchaseId { get; set; }
        public PurchaseEntity Purchase { get; set; }

        public long BusinessId { get; set; }
        public BusinessEntity Business { get; set; }

        public void SetBusinessId(long userIdentifierId) => BusinessId = userIdentifierId;

        public void SetSelected() => Selected = true;
    }
}