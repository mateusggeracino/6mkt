using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Infra.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected DbSet<T> DbSet;

        protected RepositoryBase(MktContext context)
        {
            DbSet = context.Set<T>();
        }

        public virtual async Task Add(T obj) =>
            await DbSet.AddAsync(obj);

        public virtual async Task Update(T obj)
        {
            DbSet.Update(obj);
            await Task.CompletedTask;
        }

        public virtual async Task<T> GetById(long id) =>
            await DbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remove(T obj)
        {
            DbSet.Remove(obj);
            await Task.CompletedTask;
        }

        public virtual IQueryable<T> NoTracking() =>
            DbSet.AsNoTracking();

    }
}