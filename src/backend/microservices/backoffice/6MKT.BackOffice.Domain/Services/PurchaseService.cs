using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
        }

        public async Task AddAsync(PurchaseEntity purchaseEntity)
        {
            var purchaseRegistered = await _purchaseRepository.GetByPurchase(purchaseEntity);

            if (purchaseRegistered != null)
                throw new ConflictException();

            await _purchaseRepository.Add(purchaseEntity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(PurchaseEntity purchase)
        {
            var purchaseRegistered = await _purchaseRepository.GetById(purchase.Id);

            if (purchaseRegistered == null)
                throw new NotFoundException();

            await _purchaseRepository.Update(purchase);
            await _unitOfWork.Commit();
        }

        public async Task RemoveAsync(long id)
        {
            var purchase = await _purchaseRepository.GetById(id);

            if (purchase == null)
                throw new NotFoundException();

            if (purchase.Offers.Any())
                throw new ConflictException();

            await _purchaseRepository.Remove(purchase);
            await _unitOfWork.Commit();
        }

        public async Task<PurchaseEntity> GetByIdAsync(long id) =>
            await _purchaseRepository.GetById(id);

        public async Task<PageResponse<PurchaseEntity>> GetAllAsync(PageRequest page) =>
            await _purchaseRepository.GetAll(page);
    }
}