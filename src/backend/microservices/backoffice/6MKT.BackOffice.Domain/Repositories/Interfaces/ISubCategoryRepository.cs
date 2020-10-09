using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface ISubCategoryRepository : IRepositoryBase<SubCategoryEntity>
    {
        Task<SubCategoryEntity> GetByDescription(string subCategoryDescription);
    }
}