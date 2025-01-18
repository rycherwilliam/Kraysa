using Domain.Entities;
using Infrastructure.Configurations;
using MongoDB.Driver;


namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public TransactionRepository(MongoDbConfig mongoDbConfig)
        {
            _transactions = mongoDbConfig.GetCollection<Transaction>("Transactions");
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _transactions.InsertOneAsync(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
        {
            return await _transactions.Find(t => t.AccountId == accountId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _transactions.Find(_ => true).ToListAsync();
        }
    }
}
