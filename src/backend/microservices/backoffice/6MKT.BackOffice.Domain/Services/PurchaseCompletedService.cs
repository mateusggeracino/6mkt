using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Enums;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using _6MKT.Common.EmailProviders;
using _6MKT.Common.EmailProviders.Models;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Domain.Services
{
    public class PurchaseCompletedService : IPurchaseCompletedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IPurchaseCompletedRepository _purchaseCompletedRepository;
        private readonly IEmailProvider _emailProvider;

        public PurchaseCompletedService(
            IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository, 
            IOfferRepository offerRepository, IPurchaseCompletedRepository purchaseCompletedRepository, 
            IEmailProvider emailProvider)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
            _offerRepository = offerRepository;
            _purchaseCompletedRepository = purchaseCompletedRepository;
            _emailProvider = emailProvider;
        }
        
        public async Task AddAsync(PurchaseCompletedEntity purchaseCompleted)
        {
            var purchase = await _purchaseRepository.GetById(purchaseCompleted.PurchaseId);

            if (purchase == null)
                throw new NotFoundException();

            var offer = await _offerRepository.GetById(purchaseCompleted.OfferId);

            if (offer == null)
                throw new NotFoundException();

            purchase.SetStatus(PurchaseStatusEnum.Finish);
            await _purchaseCompletedRepository.Add(purchaseCompleted);
            await _unitOfWork.Commit();

            await SendEmailToBusiness(offer, purchase);
        }

        public async Task<PurchaseCompletedEntity> GetByIdAsync(long id) =>
            await _purchaseCompletedRepository.GetById(id);
        
        private async Task SendEmailToBusiness(OfferEntity offer, PurchaseEntity purchase) =>
            await _emailProvider.SendOfferSelectAsync(new OfferSelectedEmailModel
            {
                ToEmail = offer.Business.Email,
                ToName = offer.Business.TradeName,
                PurchaseTitle = purchase.Title,
                NaturalPersonName = purchase.NaturalPerson.Name
            });
    }
}