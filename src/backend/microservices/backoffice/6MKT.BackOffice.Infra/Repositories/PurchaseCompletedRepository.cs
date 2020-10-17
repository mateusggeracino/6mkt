using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class PurchaseCompletedRepository : RepositoryBase<PurchaseCompletedEntity>, IPurchaseCompletedRepository
    {
        public PurchaseCompletedRepository(MktContext context) : base(context)
        {
        }

        public override async Task<PurchaseCompletedEntity> GetById(long id) =>
            await 
                NoTracking()
                    .Include(x => x.Purchase)
                    .Include(x => x.Offer)
                    .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<PurchaseCompletedEntity> GetByPurchaseId(long id) =>
            await NoTracking().Include(x => x.Offer).ThenInclude(x => x.Business)
                .FirstOrDefaultAsync(x => x.PurchaseId == id);
    }
}