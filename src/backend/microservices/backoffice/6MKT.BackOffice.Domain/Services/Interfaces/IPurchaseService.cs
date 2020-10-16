using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IPurchaseService : IService<PurchaseEntity>
    {
        Task<PageResponse<Purchases>> GetAllListAsync(PageRequest page);
        Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page);
    }
}