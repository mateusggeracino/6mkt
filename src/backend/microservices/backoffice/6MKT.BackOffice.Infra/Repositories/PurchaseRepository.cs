using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class PurchaseRepository : RepositoryBase<PurchaseEntity>, IPurchaseRepository
    {
        public PurchaseRepository(MktContext context) : base(context)
        {
        }

        public async Task<PurchaseEntity> GetByPurchase(PurchaseEntity purchaseEntity) =>
            await NoTracking().FirstOrDefaultAsync(x =>
                x.Description == purchaseEntity.Description ||
                x.Status == purchaseEntity.Status ||
                x.SubCategoryId == purchaseEntity.SubCategoryId);

        public override async Task<PurchaseEntity> GetById(long id) =>
            await NoTracking()
                .Include(x => x.Offers)
                    .ThenInclude(x => x.Business)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}