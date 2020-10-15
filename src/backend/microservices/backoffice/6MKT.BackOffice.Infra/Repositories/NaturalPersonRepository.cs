using System;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class NaturalPersonRepository : RepositoryBase<NaturalPersonEntity>, INaturalPersonRepository
    {
        public NaturalPersonRepository(MktContext context) : base(context)
        {
        }

        public async Task<NaturalPersonEntity> GetBySocialNumber(string socialNumber) =>
            await DbSet
                .FirstOrDefaultAsync(x => x.SocialNumber.Equals(socialNumber));

        public async Task<bool> GetByEmail(string email)
        {
            var businessDb = Db.Set<BusinessEntity>();

            return await
                   (from natural in DbSet
                    where natural.Email == email
                    select natural.Email).Union(
                    from business in businessDb
                    where business.Email == email
                    select business.Email).AnyAsync();
        }

        public async Task<IUserIdentifier> GetByProviderIdAsync(string providerId)
        {
            var user = await NoTracking().FirstOrDefaultAsync(x => x.IdentityId == Guid.Parse(providerId));
            return new UserIdentifier
            {
                Id = user.Id,
                Type = UserTypesConstants.NaturalPerson
            };
        }

        public override async Task<NaturalPersonEntity> GetById(long id) =>
            await NoTracking().Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<PageResponse<NaturalPersonEntity>> GetAll(PageRequest page, Func<IQueryable<NaturalPersonEntity>, IIncludableQueryable<NaturalPersonEntity, object>> include = null) =>
            await base.GetAll(page, source => source.Include(x => x.Address));
        
    }
}