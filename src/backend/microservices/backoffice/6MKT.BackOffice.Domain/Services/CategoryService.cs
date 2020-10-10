using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Exceptions;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryEntity category)
        {
            var categoryRegisted = await _categoryRepository.GetByDescription(category.Description);

            if(categoryRegisted != null)
                throw new ConflictException();

            await _categoryRepository.Add(category);
            await _unitOfWork.Commit();
        }

        public async Task Update(CategoryEntity category)
        {
            var categoryRegisted = await _categoryRepository.GetById(category.Id);

            if(categoryRegisted == null)
                throw new NotFoundException();

            await _categoryRepository.Update(category);
            await _unitOfWork.Commit();
        }

        public async Task Remove(long id)
        {
            var category = await _categoryRepository.GetById(id);

            if(category.SubCategories != null && category.SubCategories.Any())
                throw new ConflictException();

            await _categoryRepository.Remove(category);
            await _unitOfWork.Commit();
        }

        public async Task<CategoryEntity> GetById(long id) =>
            await _categoryRepository.GetById(id);

        public async Task<IEnumerable<CategoryEntity>> GetAll(PageRequest page) =>
            await _categoryRepository.GetAll(page);
    }
}