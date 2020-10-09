using _6MKT.BackOffice.Domain.Enums;

namespace _6MKT.BackOffice.Api.Models.Requests.Purchases
{
    public class PurchaseAddRequest
    {
        public string Title { get; set; }
        public double AveragePrice { get; set; }
        public string Description { get; set; }
        public PurchaseStatusEnum Status { get; set; } = PurchaseStatusEnum.Active;

        public long SubCategoryId { get; set; }
    }
}