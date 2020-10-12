using System;
using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
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
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INaturalPersonRepository _naturalPersonRepository;
        private readonly IUserSsoEndpoint _userSsoEndpoint;

        public NaturalPersonService(
            IUnitOfWork unitOfWork, INaturalPersonRepository naturalPersonRepository,
            IUserSsoEndpoint userSsoEndpoint)
        {
            _unitOfWork = unitOfWork;
            _naturalPersonRepository = naturalPersonRepository;
            _userSsoEndpoint = userSsoEndpoint;
        }

        public async Task AddAsync(NaturalPersonEntity naturalPersonEntity)
        {
            var naturalPerson = await _naturalPersonRepository.GetBySocialNumber(naturalPersonEntity.SocialNumber);
            if (naturalPerson != null)
                throw new ConflictException();

            var emailRegistered = await _naturalPersonRepository.GetByEmail(naturalPersonEntity.Email);
            if (emailRegistered)
                throw new ConflictException();

            var result = await CreateUserSso(naturalPersonEntity);
            if (string.IsNullOrWhiteSpace(result))
                throw new Exception();

            naturalPersonEntity.SetIdentityId(result);
            await _naturalPersonRepository.Add(naturalPersonEntity);
            await _unitOfWork.Commit();
        }

        private async Task<string> CreateUserSso(NaturalPersonEntity naturalPersonEntity)
        {
            var result = await _userSsoEndpoint.Add(new UserModel
            {
                Email = naturalPersonEntity.Email,
                Password = GeneratePassword.Build(10),
                Type = UserEnum.NaturalPerson
            });

            if (!result.IsSuccessStatusCode)
                throw new Exception(result.Error.Message);

            return result.Content;
        }

        public async Task UpdateAsync(NaturalPersonEntity naturalPersonEntity)
        {
            var naturalPerson = await _naturalPersonRepository.GetBySocialNumber(naturalPersonEntity.SocialNumber);

            if (naturalPerson == null)
                throw new NotFoundException();

            await _naturalPersonRepository.Update(naturalPersonEntity);
            await _unitOfWork.Commit();
        }

        public async Task RemoveAsync(long naturalPersonId)
        {
            var naturalPerson = await _naturalPersonRepository.GetById(naturalPersonId);

            if (naturalPerson == null)
                throw new NotFoundException();

            await _naturalPersonRepository.Update(naturalPerson);
            await _unitOfWork.Commit();
        }

        public async Task<NaturalPersonEntity> GetByIdAsync(long naturalPersonId) =>
            await _naturalPersonRepository.GetById(naturalPersonId);

        public async Task<PageResponse<NaturalPersonEntity>> GetAllAsync(PageRequest page) =>
            await _naturalPersonRepository.GetAll(page);
    }
}