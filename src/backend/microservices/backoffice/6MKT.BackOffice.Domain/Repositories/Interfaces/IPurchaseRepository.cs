using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IPurchaseRepository : IRepositoryBase<PurchaseEntity>
    {
        Task<PurchaseEntity> GetByPurchase(PurchaseEntity purchaseEntity);
        Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page);
        Task<PageResponse<Purchases>> GetAllAsync(PageRequest page);
    }
}