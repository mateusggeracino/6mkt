using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(MktContext context) : base(context)
        {
        }

        public async Task<CategoryEntity> GetByDescription(string categoryDescription) =>
            await NoTracking().FirstOrDefaultAsync(x => x.Description == categoryDescription);

        public override async Task<CategoryEntity> GetById(long id) =>
            await NoTracking().Include(x => x.SubCategories).FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<PageResponse<CategoryEntity>> GetAll(PageRequest page, 
            Func<IQueryable<CategoryEntity>, IIncludableQueryable<CategoryEntity, object>> include = null) =>
            await base.GetAll(page, source => source.Include(x => x.SubCategories));
    }
}