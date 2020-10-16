using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Infra.Repositories
{
    public class PurchaseRepository : RepositoryBase<PurchaseEntity>, IPurchaseRepository
    {
        private readonly IUserIdentifier _userIdentifier;

        public PurchaseRepository(MktContext context, IUserIdentifier userIdentifier) : base(context)
        {
            _userIdentifier = userIdentifier;
        }

        public async Task<PurchaseEntity> GetByPurchase(PurchaseEntity purchaseEntity) =>
            await NoTracking().FirstOrDefaultAsync(x =>
                x.Description == purchaseEntity.Description &&
                x.Status == purchaseEntity.Status &&
                x.SubCategoryId == purchaseEntity.SubCategoryId);

        public async Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page)
        {
            var purchaseCompletedDb = Db.Set<PurchaseCompletedEntity>();
            var businessDb = Db.Set<BusinessEntity>();
            var offerDb = Db.Set<OfferEntity>();
            var subCategoryDb = Db.Set<SubCategoryEntity>();

            var query =
                from purchase in DbSet
                from purchaseCompleted in purchaseCompletedDb.Where(x => x.PurchaseId == purchase.Id)
                join offer in offerDb on purchaseCompleted.OfferId equals offer.Id
                join business in businessDb on offer.BusinessId equals business.Id
                join subCategory in subCategoryDb on purchase.SubCategoryId equals subCategory.Id
                where purchase.NaturalPersonId == _userIdentifier.Id
                select new Purchases
                {
                    Id = purchase.Id,
                    Title = purchase.Title,
                    AveragePrice = purchase.AveragePrice,
                    Description = purchase.Description,
                    Status = purchase.Status.ToString(),
                    Quantity = purchase.Quantity,
                    Subcategory = subCategory.Description,
                    TotalOffer = purchase.Offers.Count(),
                    Offer = new Offers
                    {
                        Description = offer.Description,
                        TradeName = offer.Business.TradeName,
                        InStock = offer.InStock,
                        Price = offer.Price
                    }
                };

            var skip = page.PageIndex * page.PageSize;

            return new PageResponse<Purchases>
            {
                Count = await query.CountAsync(),
                Data = await query.Skip(skip).Take(page.PageSize).ToListAsync()
            };
        }

        public override async Task<PurchaseEntity> GetById(long id)
        {
            return await DbSet
                .Include(x => x.Offers)
                .ThenInclude(x => x.Business)
                .Include(x => x.NaturalPerson)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PageResponse<Purchases>> GetAllAsync(PageRequest page)
        {
            var purchaseCompletedDb = Db.Set<PurchaseCompletedEntity>();
            var businessDb = Db.Set<BusinessEntity>();
            var offerDb = Db.Set<OfferEntity>();
            var subCategoryDb = Db.Set<SubCategoryEntity>();

            var query =
                from purchase in DbSet
                from purchaseCompleted in purchaseCompletedDb.Where(x => x.PurchaseId == purchase.Id)
                join offer in offerDb on purchaseCompleted.OfferId equals offer.Id
                join business in businessDb on offer.BusinessId equals business.Id
                join subCategory in subCategoryDb on purchase.SubCategoryId equals subCategory.Id
                where purchase.NaturalPersonId == _userIdentifier.Id
                select new Purchases
                {
                    Id = purchase.Id,
                    Title = purchase.Title,
                    AveragePrice = purchase.AveragePrice,
                    Description = purchase.Description,
                    Status = purchase.Status.ToString(),
                    Quantity = purchase.Quantity,
                    Subcategory = subCategory.Description,
                    TotalOffer = purchase.Offers.Count(),
                    Offer = new Offers
                    {
                        Description = offer.Description,
                        TradeName = offer.Business.TradeName,
                        InStock = offer.InStock,
                        Price = offer.Price
                    }
                };

            var skip = page.PageIndex * page.PageSize;

            return new PageResponse<Purchases>
            {
                Count = await query.CountAsync(),
                Data = await query.Skip(skip).Take(page.PageSize).ToListAsync()
            };
        }
    }
}