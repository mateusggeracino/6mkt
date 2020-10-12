using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class BusinessRepository : RepositoryBase<BusinessEntity>, IBusinessRepository
    {
        public BusinessRepository(MktContext context) : base(context)
        {
        }

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
    }
}