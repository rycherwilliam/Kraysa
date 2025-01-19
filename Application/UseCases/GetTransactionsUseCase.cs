using Application.Repositories.Interfaces;
using Application.UseCases.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetTransactionsUseCase : IGetTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        { 
            return await _transactionRepository.GetAllAsync();
        }
    }
}
