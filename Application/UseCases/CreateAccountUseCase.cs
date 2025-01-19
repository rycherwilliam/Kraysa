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
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }
        

        public async Task ExecuteAsync(AccountDto account)
        {
            Account accountObject = AccountAdapter.ToDomain(account);

            await _accountRepository.AddAsync(accountObject);
        }
    }
}
