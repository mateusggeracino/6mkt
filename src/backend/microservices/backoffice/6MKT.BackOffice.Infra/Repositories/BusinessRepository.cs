using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;
using Microsoft.EntityFrameworkCore.Query;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class BusinessRepository : RepositoryBase<BusinessEntity>, IBusinessRepository
    {
        public BusinessRepository(MktContext context) : base(context)
        {
        }

        public override async Task<PageResponse<BusinessEntity>> GetAll(PageRequest page, Func<IQueryable<BusinessEntity>, IIncludableQueryable<BusinessEntity, object>> include = null) =>
            await base.GetAll(page, source => source.Include(x => x.SubCategories).ThenInclude(x => x.SubCategory));

        public async Task<BusinessEntity> GetByRegisteredNumber(string registeredNumber) =>
            await DbSet
                .FirstOrDefaultAsync(x => x.RegisteredNumber.Equals(registeredNumber));

        public async Task<bool> GetByEmail(string email)
        {
            var naturalPersonDb = Db.Set<NaturalPersonEntity>();

            return await
                (from business in DbSet
                 where business.Email == email
                 select business.Email).Union(
                    from natural in naturalPersonDb
                    where natural.Email == email
                    select natural.Email).AnyAsync();
        }

        public async Task<bool> VerificationCategoriesBusiness(long businessId, long subCategoryId) =>
            await NoTracking().AnyAsync(x => 
                x.Id == businessId && 
                x.SubCategories.Any(s => s.SubCategoryId == subCategoryId));

        public async Task<IEnumerable<Tuple<string, string>>> GetEmailsBySubcategoryAsync(long subCategoryId) =>
            await
                NoTracking()
                    .Where(x => x.SubCategories.Any(s => s.SubCategoryId == subCategoryId))
                    .Select(x => Tuple.Create(x.Email, x.TradeName))
                    .ToListAsync();

        public async Task<IUserIdentifier> GetByProviderIdAsync(string providerId)
        {
            var user = await NoTracking().FirstOrDefaultAsync(x => x.IdentityId == Guid.Parse(providerId));
            return new UserIdentifier
            {
                Id = user.Id,
                Type = UserTypesConstants.Business
            };
        } 
        

        public override async Task<BusinessEntity> GetById(long id) =>
            await NoTracking().Include(x => x.SubCategories).ThenInclude(x => x.SubCategory).FirstOrDefaultAsync(x => x.Id == id);
    }
}