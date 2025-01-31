﻿using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
