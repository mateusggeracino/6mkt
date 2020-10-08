using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface INaturalPersonRepository : IRepositoryBase<NaturalPersonEntity>
    {
        Task<NaturalPersonEntity> GetBySocialNumber(string socialNumber);
    }
}