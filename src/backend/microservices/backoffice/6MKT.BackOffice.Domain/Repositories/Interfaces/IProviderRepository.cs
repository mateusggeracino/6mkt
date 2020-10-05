using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IProviderRepository : IRepositoryBase<ProviderEntity>
    {
        Task<ProviderEntity> GetBySocialNumber(string socialNumber);
    }
}