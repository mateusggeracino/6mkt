using System;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Enums;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Password;
using _6MKT.BackOffice.Domain.ValueObjects.Token;
using _6MKT.BackOffice.Domain.Wrapper.Endpoint;
using _6MKT.BackOffice.Domain.Wrapper.Models.Request;

namespace _6MKT.BackOffice.Domain.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessRepository _businessRepository;
        private readonly IUserSsoEndpoint _userSsoEndpoint;

        public BusinessService(
            IUnitOfWork unitOfWork, IBusinessRepository businessRepository,
            IUserSsoEndpoint userSsoEndpoint)
        {
            _unitOfWork = unitOfWork;
            _businessRepository = businessRepository;
            _userSsoEndpoint = userSsoEndpoint;
        }

        public async Task AddAsync(BusinessEntity businessEntity)
        {
            var business = await _businessRepository.GetByRegisteredNumber(businessEntity.RegisteredNumber);
            if (business != null)
                throw new ConflictException();

            var emailRegistered = await _businessRepository.GetByEmail(businessEntity.Email);
            if (emailRegistered)
                throw new ConflictException();

            var result = await CreateUserSso(businessEntity);

            if (string.IsNullOrWhiteSpace(result))
                throw new Exception();

            businessEntity.SetIdentityId(result);
            await _businessRepository.Add(businessEntity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(BusinessEntity businessEntity)
        {
            var business = await _businessRepository.GetByRegisteredNumber(businessEntity.RegisteredNumber);

            if (business == null)
                throw new NotFoundException();

            await _businessRepository.Update(business);
            await _unitOfWork.Commit();
        }

        public async Task RemoveAsync(long businessId)
        {
            var business = await _businessRepository.GetById(businessId);

            if (business == null)
                throw new NotFoundException();

            await _businessRepository.Update(business);
            await _unitOfWork.Commit();
        }

        public async Task<BusinessEntity> GetByIdAsync(long businessId) =>
            await _businessRepository.GetById(businessId);

        public async Task<PageResponse<BusinessEntity>> GetAllAsync(PageRequest page) =>
            await _businessRepository.GetAll(page);

        private async Task<string> CreateUserSso(BusinessEntity businessEntity)
        {
            var result = await _userSsoEndpoint.Add(new UserModel
            {
                Email = businessEntity.Email,
                Password = GeneratePassword.Build(length: 10),
                Type = UserEnum.Business
            });

            if(!result.IsSuccessStatusCode)
                throw new Exception(result.Error.Message);

            return result.Content;
        }
    }
}