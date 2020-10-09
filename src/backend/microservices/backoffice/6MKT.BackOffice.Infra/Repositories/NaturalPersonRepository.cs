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
    }
}