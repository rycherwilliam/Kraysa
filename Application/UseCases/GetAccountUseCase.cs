using Application.Adapters;
using Application.Models;
using Application.Repositories.Interfaces;
using Application.UseCases.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetAccountUseCase : IGetAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Account> GetByIdAsync(Guid accountId)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            return await _accountRepository.GetByIdAsync(accountId);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }       
    }
}
