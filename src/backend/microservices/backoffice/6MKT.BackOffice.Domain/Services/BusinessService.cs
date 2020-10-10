using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessRepository _businessRepository;

        public BusinessService(IUnitOfWork unitOfWork, IBusinessRepository businessRepository)
        {
            _unitOfWork = unitOfWork;
            _businessRepository = businessRepository;
        }

        public async Task Add(BusinessEntity businessEntity)
        {
            var business = await _businessRepository.GetByRegisteredNumber(businessEntity.RegisteredNumber);

            if (business != null)
                throw new ConflictException();

            await _businessRepository.Add(businessEntity);
            await _unitOfWork.Commit();
        }

        public async Task Update(BusinessEntity businessEntity)
        {
            var business = await _businessRepository.GetByRegisteredNumber(businessEntity.RegisteredNumber);

            if (business == null)
                throw new NotFoundException();

            await _businessRepository.Update(business);
            await _unitOfWork.Commit();
        }

        public async Task Remove(long businessId)
        {
            var business = await _businessRepository.GetById(businessId);

            if (business == null)
                throw new NotFoundException();

            await _businessRepository.Update(business);
            await _unitOfWork.Commit();
        }

        public async Task<BusinessEntity> GetById(long businessId) =>
            await _businessRepository.GetById(businessId);

        public async Task<IEnumerable<BusinessEntity>> GetAll(PageRequest page) =>
            await _businessRepository.GetAll(page);
    }
}