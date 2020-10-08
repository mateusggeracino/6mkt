using System.Collections.Generic;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Exceptions;

namespace _6MKT.BackOffice.Domain.Services
{
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public NaturalPersonService(IUnitOfWork unitOfWork, INaturalPersonRepository naturalPersonRepository)
        {
            _unitOfWork = unitOfWork;
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task Add(NaturalPersonEntity naturalPersonEntity)
        {
            var naturalPerson = await _naturalPersonRepository.GetBySocialNumber(naturalPersonEntity.SocialNumber);

            if (naturalPerson != null)
                throw new ConflictException();

            await _naturalPersonRepository.Add(naturalPersonEntity);
            await _unitOfWork.Commit();
        }

        public async Task Update(NaturalPersonEntity naturalPersonEntity)
        {
            var naturalPerson = await _naturalPersonRepository.GetBySocialNumber(naturalPersonEntity.SocialNumber);

            if (naturalPerson == null)
                throw new NotFoundException();

            await _naturalPersonRepository.Update(naturalPersonEntity);
            await _unitOfWork.Commit();
        }

        public async Task Remove(long naturalPersonId)
        {
            var naturalPerson = await _naturalPersonRepository.GetById(naturalPersonId);

            if (naturalPerson == null)
                throw new NotFoundException();

            await _naturalPersonRepository.Update(naturalPerson);
            await _unitOfWork.Commit();
        }

        public async Task<NaturalPersonEntity> GetById(long naturalPersonId) =>
            await _naturalPersonRepository.GetById(naturalPersonId);

        public async Task<IEnumerable<NaturalPersonEntity>> GetAll() =>
            await _naturalPersonRepository.GetAll();
    }
}