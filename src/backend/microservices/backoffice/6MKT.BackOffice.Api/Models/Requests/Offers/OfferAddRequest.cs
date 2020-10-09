namespace _6MKT.BackOffice.Api.Models.Requests.Offers
{
    public class OfferAddRequest
    {
        public string Description { get; set; }
        public bool InStock { get; set; }

        public long PurchaseId { get; set; }
        public long BusinessId { get; set; }
    }
}