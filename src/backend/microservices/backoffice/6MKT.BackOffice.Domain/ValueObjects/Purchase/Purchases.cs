using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Enums;

namespace _6MKT.BackOffice.Domain.ValueObjects.Purchase
{
    public class Purchases
    {
        public string Title { get; set; }
        public double AveragePrice { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public string Subcategory { get; set; }
        public Offers Offer { get; set; }
        public int TotalOffer { get; set; }
    }
}