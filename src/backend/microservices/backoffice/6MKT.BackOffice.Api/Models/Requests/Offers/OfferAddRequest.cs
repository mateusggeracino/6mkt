namespace _6MKT.BackOffice.Api.Models.Requests.Offers
{
    public class OfferAddRequest
    {
        public string Description { get; set; }
        public bool InStock { get; set; }
        public double Price { get; set; }

        public long PurchaseId { get; set; }
    }
}