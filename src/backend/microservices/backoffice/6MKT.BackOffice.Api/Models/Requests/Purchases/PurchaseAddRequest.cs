using System;
using _6MKT.BackOffice.Domain.Enums;
using Newtonsoft.Json;

namespace _6MKT.BackOffice.Api.Models.Requests.Purchases
{
    public class PurchaseAddRequest
    {
        public string Title { get; set; }
        public double AveragePrice { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public long SubCategoryId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public PurchaseStatusEnum Status { get; set; } = PurchaseStatusEnum.Active;
    }
}