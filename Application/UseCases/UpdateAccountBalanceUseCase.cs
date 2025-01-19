using Application.Repositories.Interfaces;
using Application.UseCases.Interfaces;

namespace Application.UseCases
{
    public class UpdateAccountBalanceUseCase: IUpdateAccountBalanceUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountBalanceUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task ExecuteAsync(Guid accountId, decimal amount)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            // Retrieve the account
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
                throw new ArgumentException("Account does not exist.");

            // Update the balance
            account.UpdateBalance(amount);

            // Save changes
            await _accountRepository.UpdateAsync(account);
        }
    }
}
