using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Domain.Repositories.Interfaces
{
    public interface IBusinessRepository : IRepositoryBase<BusinessEntity>
    {
        Task<BusinessEntity> GetByRegisteredNumber(string businessEntityRegisteredNumber);
        Task<bool> GetByEmail(string email);
        Task<bool> VerificationCategoriesBusiness(long subCategoryId, long purchaseSubCategoryId);
        Task<IEnumerable<Tuple<string, string>>> GetEmailsBySubcategoryAsync(long subCategoryId);
        Task<IUserIdentifier> GetByProviderIdAsync(string providerId);
    }
}