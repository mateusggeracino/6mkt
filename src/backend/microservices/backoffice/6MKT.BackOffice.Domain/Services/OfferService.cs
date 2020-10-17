using System;
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
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOfferRepository _offerRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly IEmailProvider _emailProvider;
        private readonly IUserIdentifier _userIdentifier;

        public OfferService(
            IUnitOfWork unitOfWork, IOfferRepository offerRepository,
            IPurchaseRepository purchaseRepository, IBusinessRepository businessRepository,
            IEmailProvider emailProvider, IUserIdentifier userIdentifier)
        {
            _unitOfWork = unitOfWork;
            _offerRepository = offerRepository;
            _purchaseRepository = purchaseRepository;
            _businessRepository = businessRepository;
            _emailProvider = emailProvider;
            _userIdentifier = userIdentifier;
        }

        public async Task AddAsync(OfferEntity offer)
        {
            var purchase = await ValidationPurchase(offer);
            var business = await ValidationBusiness(_userIdentifier.Id, purchase);

            offer.SetBusinessId(_userIdentifier.Id);

            await _offerRepository.Add(offer);
            await _unitOfWork.Commit();

            await SendEmail(purchase, business);
        }

        public async Task UpdateAsync(OfferEntity offer)
        {
            var offerRegistered = await _offerRepository.GetById(offer.Id);

            if (offerRegistered == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            if (offerRegistered.Purchase?.Status == PurchaseStatusEnum.Finish ||
               offerRegistered.Purchase?.Status == PurchaseStatusEnum.Cancel)
                throw new ConflictException(MessageExceptionConstants.PurchaseFinishOrCancelException);

            await _offerRepository.Update(offer);
            await _unitOfWork.Commit();
        }

        public async Task RemoveAsync(long offerId)
        {
            var offer = await _offerRepository.GetById(offerId);

            if (offer == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            await _offerRepository.Remove(offer);
            await _unitOfWork.Commit();
        }

        public async Task<OfferEntity> GetByIdAsync(long offerId) =>
            await _offerRepository.GetById(offerId);

        public async Task<PageResponse<OfferEntity>> GetAllAsync(PageRequest page) =>
            await _offerRepository.GetAll(page);

        private async Task<BusinessEntity> ValidationBusiness(long businessId, PurchaseEntity purchase)
        {
            //var businessAllowed =
            //    await _businessRepository.VerificationCategoriesBusiness(businessId, purchase.SubCategoryId);

            //if (!businessAllowed)
            //    throw new ConflictException(MessageExceptionConstants.NotInYourSubcategoriesException);

            var business = await _businessRepository.GetById(businessId);

            if (business == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            return business;
        }

        private async Task<PurchaseEntity> ValidationPurchase(OfferEntity offer)
        {
            var purchase = await _purchaseRepository.GetById(offer.PurchaseId);

            if(purchase.Status == PurchaseStatusEnum.Finish || purchase.Status == PurchaseStatusEnum.Cancel)
                throw new ConflictException(MessageExceptionConstants.PurchaseFinishOrCancelException);

            if (purchase == null)
                throw new NotFoundException(MessageExceptionConstants.NotFoundException);

            if (purchase.Offers != null && purchase.Offers.Any(x => x.CreatedId == _userIdentifier.Id))
                throw new ConflictException(MessageExceptionConstants.CreateTwoOfferOnSamePurchaseException);

            return purchase;
        }

        private async Task SendEmail(PurchaseEntity purchase, BusinessEntity business) =>
            await _emailProvider.SendPublishedOfferAsync(new PublishedOfferEmailModel
            {
                ToEmail = purchase.NaturalPerson.Email,
                ToName = purchase.NaturalPerson.Name,
                BusinessTradename = business.TradeName,
                PurchaseTitle = purchase.Title
            });

    }
}