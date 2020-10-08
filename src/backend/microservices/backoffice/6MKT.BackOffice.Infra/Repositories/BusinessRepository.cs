using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class BusinessRepository : RepositoryBase<BusinessEntity>, IBusinessRepository
    {
        public BusinessRepository(AppContext context) : base(context)
        {
        }

        public async Task<BusinessEntity> GetByRegisteredNumber(string registeredNumber) =>
            await DbSet
                .FirstOrDefaultAsync(x => x.RegisteredNumber.Equals(registeredNumber));
    }
}