using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class ProviderRepository : RepositoryBase<ProviderEntity>, IProviderRepository
    {
        public ProviderRepository(AppContext context) : base(context)
        {
        }

        public async Task<ProviderEntity> GetBySocialNumber(string socialNumber) =>
            await NoTracking()
                .FirstOrDefaultAsync(x => x.SocialNumber.Equals(socialNumber));
    }
}