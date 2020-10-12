using System;
using _6MKT.BackOffice.Domain.Entities.Base;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using Microsoft.EntityFrameworkCore.Query;

namespace _6MKT.BackOffice.Infra.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected DbSet<T> DbSet;
        protected MktContext Db;
        protected RepositoryBase(MktContext context)
        {
            Db = context;
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

        public virtual async Task<PageResponse<T>> GetAll(PageRequest page,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = NoTracking().AsQueryable();

            if (include != null)
                query = include(query);

            var skip = page.PageIndex * page.PageSize;

            query = query.Skip(skip).Take(page.PageSize);

            return new PageResponse<T>
            {
                Data = await query.ToListAsync(),
                Count = await NoTracking().CountAsync()
            };
        }

        public async Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> predicate) =>
            await NoTracking().Where(predicate).ToListAsync();

        public virtual async Task Remove(T obj)
        {
            DbSet.Remove(obj);
            await Task.CompletedTask;
        }

        public virtual IQueryable<T> NoTracking() =>
            DbSet.AsNoTracking();

    }
}