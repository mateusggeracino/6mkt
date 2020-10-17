using System;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IPurchaseCompletedRepository : IRepositoryBase<PurchaseCompletedEntity>
    {
        Task<PurchaseCompletedEntity> GetByPurchaseId(long id);
    }
}