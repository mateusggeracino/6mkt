using _6MKT.BackOffice.Api.Models.Responses.Business;

namespace _6MKT.BackOffice.Api.Models.Responses.Offers
{
    public class OfferResponse
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public double Price { get; set; }
        public bool Selected { get; set; }
        
        public BusinessResponse Business { get; set; }
    }
}