using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetTransactionsUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<Transaction>> Execute(Guid accountId)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            return await _transactionRepository.GetByAccountIdAsync(accountId);
        }
    }
}
