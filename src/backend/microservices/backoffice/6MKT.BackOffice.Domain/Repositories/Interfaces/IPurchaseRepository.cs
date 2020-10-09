using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IPurchaseRepository : IRepositoryBase<PurchaseEntity>
    {
        Task<PurchaseEntity> GetByPurchase(PurchaseEntity purchaseEntity);
    }
}