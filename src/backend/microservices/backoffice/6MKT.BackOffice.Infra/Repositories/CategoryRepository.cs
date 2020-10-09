using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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

        public override async Task<IEnumerable<CategoryEntity>> GetAll() =>
            await NoTracking().Include(x => x.SubCategories).ToListAsync();
    }
}