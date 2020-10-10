using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SubCategoryService(IUnitOfWork unitOfWork, ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(SubCategoryEntity subCategory)
        {
            var subCategoryRegistered = await _subCategoryRepository.GetByDescription(subCategory.Description);

            if(subCategoryRegistered != null)
                throw new ConflictException();

            var category = await _categoryRepository.GetById(subCategory.CategoryId);

            if(category == null)
                throw new NotFoundException();

            await _subCategoryRepository.Add(subCategory);
            await _unitOfWork.Commit();
        }

        public async Task Update(SubCategoryEntity subCategory)
        {
            var subCategoryRegistered = await _subCategoryRepository.GetById(subCategory.Id);

            if(subCategoryRegistered == null)
                throw new NotFoundException();

            if (subCategoryRegistered.CategoryId != subCategory.CategoryId)
            {
                var category = await _categoryRepository.GetById(subCategory.CategoryId);

                if (category == null)
                    throw new NotFoundException();
            }
            
            await _subCategoryRepository.Update(subCategory);
            await _unitOfWork.Commit();
        }

        public async Task Remove(long id)
        {
            var subCategoryRegistered = await _subCategoryRepository.GetById(id);

            if(subCategoryRegistered == null)
                throw new NotFoundException();

            await _subCategoryRepository.Remove(subCategoryRegistered);
            await _unitOfWork.Commit();
        }

        public async Task<SubCategoryEntity> GetById(long id) =>
            await _subCategoryRepository.GetById(id);

        public async Task<IEnumerable<SubCategoryEntity>> GetAll(PageRequest page) =>
            await _subCategoryRepository.GetAll(page);
    }
}