using System;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Services
{
    public class UserIdentifierService : IUserIdentifierService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public UserIdentifierService(INaturalPersonRepository naturalPersonRepository, IBusinessRepository businessRepository)
        {
            _naturalPersonRepository = naturalPersonRepository;
            _businessRepository = businessRepository;
        }

        public async Task<IUserIdentifier> GetUserAsync(string providerId, string type)
        {
            return type switch
            {
                UserTypesConstants.Business => await _businessRepository.GetByProviderIdAsync(providerId),
                UserTypesConstants.NaturalPerson => await _naturalPersonRepository.GetByProviderIdAsync(providerId),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}