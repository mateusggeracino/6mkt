using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities.Base;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task Add(T obj);
        Task Update(T obj);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task Remove(T obj);
        IQueryable<T> NoTracking();
    }
}