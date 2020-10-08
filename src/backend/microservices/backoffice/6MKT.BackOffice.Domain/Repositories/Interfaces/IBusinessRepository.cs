using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IBusinessRepository : IRepositoryBase<BusinessEntity>
    {
        Task<BusinessEntity> GetByRegisteredNumber(string businessEntityRegisteredNumber);
    }
}