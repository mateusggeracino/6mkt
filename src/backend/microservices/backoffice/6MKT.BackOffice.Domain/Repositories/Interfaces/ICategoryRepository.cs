using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<CategoryEntity>
    {
        Task<CategoryEntity> GetByDescription(string categoryDescription);
    }
}