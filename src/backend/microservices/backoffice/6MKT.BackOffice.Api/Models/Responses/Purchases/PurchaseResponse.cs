using System.Collections.Generic;
using _6MKT.BackOffice.Api.Models.Responses.NaturalPeople;
using _6MKT.BackOffice.Api.Models.Responses.Offers;
using _6MKT.BackOffice.Api.Models.Responses.SubCategories;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Enums;

namespace _6MKT.BackOffice.Api.Models.Responses.Purchases
{
    public class PurchaseResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double AveragePrice { get; set; }
        public string Description { get; set; }
        public PurchaseStatusEnum Status { get; set; }

        public SubCategoryResponse SubCategory { get; set; }

        public NaturalPersonResponse NaturalPerson { get; set; }

        public IEnumerable<OfferResponse> Offers { get; set; }
    }
}