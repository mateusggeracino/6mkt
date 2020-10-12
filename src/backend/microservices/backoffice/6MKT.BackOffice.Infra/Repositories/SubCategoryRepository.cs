﻿using System;
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
    public class SubCategoryRepository : RepositoryBase<SubCategoryEntity>, ISubCategoryRepository
    {
        public SubCategoryRepository(MktContext context) : base(context)
        {
        }

        public async Task<SubCategoryEntity> GetByDescription(string subCategoryDescription) =>
            await NoTracking().FirstOrDefaultAsync(x => x.Description == subCategoryDescription);

        public override async Task<SubCategoryEntity> GetById(long id) =>
            await NoTracking().Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<PageResponse<SubCategoryEntity>> GetAll(PageRequest page,
            Func<IQueryable<SubCategoryEntity>, IIncludableQueryable<SubCategoryEntity, object>> include = null) =>
            await base.GetAll(page, source => source.Include(x => x.Category));
    }
}