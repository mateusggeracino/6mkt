using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IPurchaseService : IService<PurchaseEntity>
    {
        Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page);
    }
}