using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface INaturalPersonRepository : IRepositoryBase<NaturalPersonEntity>
    {
        Task<NaturalPersonEntity> GetBySocialNumber(string socialNumber);
        Task<bool> GetByEmail(string email);
        Task<IUserIdentifier> GetByProviderIdAsync(string providerId);
    }
}