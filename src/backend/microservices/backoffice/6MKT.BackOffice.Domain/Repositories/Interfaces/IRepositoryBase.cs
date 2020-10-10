using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using Microsoft.EntityFrameworkCore.Query;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task Add(T obj);
        Task Update(T obj);
        Task<T> GetById(long id);
        Task Remove(T obj);
        IQueryable<T> NoTracking();
        Task<IEnumerable<T>> GetAll(PageRequest page,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}