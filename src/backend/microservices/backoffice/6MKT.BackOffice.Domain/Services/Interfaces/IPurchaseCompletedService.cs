﻿using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;

namespace _6MKT.BackOffice.Domain.Services.Interfaces
{
    public interface IPurchaseCompletedService
    {
        Task AddAsync(PurchaseCompletedEntity purchaseCompleted);
        Task<PurchaseCompletedEntity> GetByIdAsync(long purchaseCompletedId);
    }
}