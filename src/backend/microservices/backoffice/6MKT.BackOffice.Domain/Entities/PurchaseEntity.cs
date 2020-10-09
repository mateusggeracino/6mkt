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

        public long SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }

        public IEnumerable<OfferEntity> Offers { get; set; }
    }
}