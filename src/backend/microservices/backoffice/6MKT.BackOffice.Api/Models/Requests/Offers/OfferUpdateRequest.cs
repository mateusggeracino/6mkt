namespace _6MKT.BackOffice.Api.Models.Requests.Offers
{
    public class OfferUpdateRequest
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public double Price { get; set; }
    }
}