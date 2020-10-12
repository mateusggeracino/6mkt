using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task RemoveAsync(long objId);
        Task<T> GetByIdAsync(long objId);
        Task<PageResponse<T>> GetAllAsync(PageRequest page);
    }
}