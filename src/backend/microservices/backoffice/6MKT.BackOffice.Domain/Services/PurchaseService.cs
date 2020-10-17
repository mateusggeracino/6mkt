﻿using System.Collections.Generic;
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

        public PurchaseService(
            IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository,
            IOfferRepository offerRepository, IEmailProvider emailProvider, 
            IBusinessRepository businessRepository, ISubCategoryRepository subCategoryRepository, 
            IUserIdentifier userIdentifier)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
            _offerRepository = offerRepository;
            _emailProvider = emailProvider;
            _businessRepository = businessRepository;
            _subCategoryRepository = subCategoryRepository;
            _userIdentifier = userIdentifier;
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
            var emails = await _businessRepository.GetEmailsBySubcategoryAsync(purchase.SubCategoryId);

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
        
        public async Task<PageResponse<Purchases>> GetAllListAsync(PageRequest page) =>
            await _purchaseRepository.GetAllAsync(page);

        public async Task<PageResponse<Purchases>> GetAllByNaturalPersonAsync(PageRequest page) =>
            await _purchaseRepository.GetAllByNaturalPersonAsync(page);
    }
}