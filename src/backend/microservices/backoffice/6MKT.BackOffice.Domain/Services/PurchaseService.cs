using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Enums;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.Common.EmailProviders;
using _6MKT.Common.EmailProviders.Models;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IEmailProvider _emailProvider;
        private readonly IBusinessRepository _businessRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IUserIdentifier _userIdentifier;
        private readonly IPurchaseCompletedRepository _completedRepository;

        public PurchaseService(
            IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository,
            IOfferRepository offerRepository, IEmailProvider emailProvider, 
            IBusinessRepository businessRepository, ISubCategoryRepository subCategoryRepository, 
            IUserIdentifier userIdentifier, IPurchaseCompletedRepository completedRepository)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
            _offerRepository = offerRepository;
            _emailProvider = emailProvider;
            _businessRepository = businessRepository;
            _subCategoryRepository = subCategoryRepository;
            _userIdentifier = userIdentifier;
            _completedRepository = completedRepository;
        }

        public async Task AddAsync(PurchaseEntity purchaseEntity)
        {
            //var purchaseRegistered = await _purchaseRepository.GetByPurchase(purchaseEntity);

            //if (purchaseRegistered != null)
            //    throw new ConflictException(MessageExceptionConstants.RegisteredException);

            purchaseEntity.SetNaturalPersonId(_userIdentifier.Id);
            await _purchaseRepository.Add(purchaseEntity);
            await _unitOfWork.Commit();

            await SendEmailToAllBusinessOnSubcategory(purchaseEntity).ConfigureAwait(false);
        }

        private async Task SendEmailToAllBusinessOnSubcategory(PurchaseEntity purchase)
        {
            var subCategory = await _subCategoryRepository.GetById(purchase.SubCategoryId);
            var emails = (await _businessRepository.GetEmailsBySubcategoryAsync(purchase.SubCategoryId)).ToList();

            if (!emails.Any())
                return;

            await _emailProvider.SendEmailToAllBusinessOnSubcategoryAsync(new EmailsToBusiness
            {
                PurchaseTitle = purchase.Title,
                SubcategoryName = subCategory.Description,
                Emails = emails
            });
        }
        
        public async Task UpdateAsync(PurchaseEntity purchase)
        {
            var purchaseRegistered = await _purchaseRepository.GetById(purchase.Id);

            if (purchaseRegistered == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            await _purchaseRepository.Update(purchase);
            await _unitOfWork.Commit();
        }

        public async Task RemoveAsync(long id)
        {
            var purchase = await _purchaseRepository.GetById(id);

            if (purchase == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            if (purchase.Offers.Any())
                throw new ConflictException(MessageExceptionConstants.RelatedWithAnotherObject);

            await _purchaseRepository.Remove(purchase);
            await _unitOfWork.Commit();
        }

        public async Task<PurchaseEntity> GetByIdAsync(long id) =>
            await _purchaseRepository.GetById(id);

        public async Task<PageResponse<PurchaseEntity>> GetAllAsync(PageRequest page) =>
            await _purchaseRepository.GetAll(page);

        public async Task<PageResponse<Purchases>> GetAllListAsync(PageRequest page)
        {
            var response = await _purchaseRepository.GetAllAsync(page);
            await HandlerOffer(response);
            return response;
        }
            

        public async Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page)
        {
            var response = await _purchaseRepository.GetAllByNaturalPersonAsync(page);

            await HandlerOffer(response);

            return response;
        }

        private async Task HandlerOffer(PageResponse<Purchases> response)
        {
            foreach (var purchase in response.Data)
            {
                var offer = await _completedRepository.GetByPurchaseId(purchase.Id);

                if (offer == null)
                    continue;

                purchase.Offer = new Offers
                {
                    Description = offer.Offer.Description,
                    TradeName = offer.Offer.Business.TradeName,
                    InStock = offer.Offer.InStock,
                    Price = offer.Offer.Price
                };
            }
        }
    }
}