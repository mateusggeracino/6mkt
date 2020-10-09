using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Enums;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;

namespace _6MKT.BackOffice.Domain.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOfferRepository _offerRepository;
        private readonly IPurchaseService _purchaseService;

        public OfferService(IUnitOfWork unitOfWork, IOfferRepository offerRepository, IPurchaseService purchaseService)
        {
            _unitOfWork = unitOfWork;
            _offerRepository = offerRepository;
            _purchaseService = purchaseService;
        }

        public async Task Add(OfferEntity offer)
        {
            var purchase = await _purchaseService.GetById(offer.PurchaseId);

            if (purchase == null)
                throw new NotFoundException();

            if (purchase.Offers != null && purchase.Offers.Any(x => x.BusinessId == offer.BusinessId))
                throw new ConflictException();

            await _offerRepository.Add(offer);
            await _unitOfWork.Commit();
        }

        public async Task Update(OfferEntity offer)
        {
            var offerRegistered = await _offerRepository.GetById(offer.Id);

            if (offerRegistered == null)
                throw new NotFoundException();

            if (offerRegistered.Purchase?.Status == PurchaseStatusEnum.Finish ||
               offerRegistered.Purchase?.Status == PurchaseStatusEnum.Cancel)
                throw new ConflictException();

            await _offerRepository.Update(offer);
            await _unitOfWork.Commit();
        }

        public async Task Remove(long offerId)
        {
            var offer = await _offerRepository.GetById(offerId);

            if (offer == null)
                throw new NotFoundException();

            await _offerRepository.Remove(offer);
            await _unitOfWork.Commit();
        }

        public async Task<OfferEntity> GetById(long offerId) =>
            await _offerRepository.GetById(offerId);

        public async Task<IEnumerable<OfferEntity>> GetAll() =>
            await _offerRepository.GetAll();
    }
}