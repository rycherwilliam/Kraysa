using Application.Adapters;
using Application.Models;
using Application.Repositories.Interfaces;
using Application.UseCases.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class AddTransactionUseCase : IAddTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public AddTransactionUseCase(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task ExecuteAsync(TransactionDto transactionDto)
        {
            var transaction = TransactionAdapter.ToDomain(transactionDto);

            var account = await _accountRepository.GetByIdAsync(transaction.AccountId);
            if (account == null)
                throw new ArgumentException("Account does not exist.");

            await _transactionRepository.AddAsync(transaction);

            decimal balanceAdjustment = transaction is Income ? transaction.Amount : -transaction.Amount;
            account.UpdateBalance(balanceAdjustment);

            await _accountRepository.UpdateAsync(account);
        }
    }
}
