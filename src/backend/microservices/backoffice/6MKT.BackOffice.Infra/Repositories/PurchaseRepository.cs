using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public override async Task<PurchaseEntity> GetById(long id)
        {
            return await DbSet
                .Include(x => x.Offers)
                .ThenInclude(x => x.Business)
                .Include(x => x.NaturalPerson)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}