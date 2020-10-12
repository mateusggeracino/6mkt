using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IPurchaseService : IService<PurchaseEntity>
    {
        Task AddAsync(PurchaseEntity purchase);
    }
}