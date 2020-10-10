using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Remove(long objId);
        Task<T> GetById(long objId);
        Task<IEnumerable<T>> GetAll(PageRequest page);
    }
}