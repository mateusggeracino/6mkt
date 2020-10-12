using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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
    }
}