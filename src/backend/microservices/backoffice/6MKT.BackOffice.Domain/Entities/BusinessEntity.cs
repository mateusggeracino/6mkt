using _6MKT.BackOffice.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class BusinessEntity : Entity
    {
        public Guid IdentityId { get; set; }
        public string Email { get; set; }
        public string RegisteredNumber { get; set; }
        public string TradeName { get; set; }
        public string Phone { get; set; }

        public long AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public IEnumerable<BusinessSubCategory> SubCategories { get; set; }
        public IEnumerable<OfferEntity> Offers { get; set; }

        public void SetIdentityId(string id) => IdentityId = Guid.Parse(id);
    }

    public class BusinessSubCategory
    {
        public long BusinessId { get; set; }
        public BusinessEntity Business{ get; set; }

        public long SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }
    }
}