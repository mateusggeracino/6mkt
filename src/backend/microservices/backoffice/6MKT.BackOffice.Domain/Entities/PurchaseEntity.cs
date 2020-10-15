using System;
using _6MKT.BackOffice.Domain.Entities.Base;
using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Enums;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class PurchaseEntity : Entity
    {
        public string Title { get; set; }
        public double AveragePrice { get; set; }
        public string Description { get; set; }
        public PurchaseStatusEnum Status { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset Date { get; set; }

        public long SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }

        public long NaturalPersonId { get; set; }
        public NaturalPersonEntity NaturalPerson { get; set; }

        public IEnumerable<OfferEntity> Offers { get; set; }

        public void SetStatus(PurchaseStatusEnum status) => Status = status;

        public void SetNaturalPersonId(long userIdentifierId) => NaturalPersonId = userIdentifierId;
    }
}