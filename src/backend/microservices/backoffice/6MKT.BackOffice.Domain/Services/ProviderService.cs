using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;

namespace _6MKT.BackOffice.Domain.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ProviderEntity providerEntity)
        {
            var provider = await _providerRepository.GetBySocialNumber(providerEntity.SocialNumber);

            if (provider != null)
                throw new ConflictException();

            await _providerRepository.Add(providerEntity);
            await _unitOfWork.Commit();
        }
    }
}