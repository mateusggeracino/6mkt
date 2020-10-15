using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Entities
{
    public class PurchaseCompletedEntity : Entity
    {
        public long PurchaseId { get; set; }
        public PurchaseEntity Purchase { get; set; }

        public long OfferId { get; set; }
        public OfferEntity Offer { get; set; }

        public static PurchaseCompletedEntity New(in long purchaseId, in long offerId) =>
            new PurchaseCompletedEntity { PurchaseId = purchaseId, OfferId = offerId };
    }
}