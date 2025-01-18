using Domain.Entities;
using Infrastructure.Configurations;
using Application.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountRepository(MongoDbConfig mongoDbConfig)
        {
            _accounts = mongoDbConfig.GetCollection<Account>("Accounts");
        }

        public async Task<Account> GetByIdAsync(Guid accountId)
        {
            return await _accounts.Find(a => a.Id == accountId).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            await _accounts.ReplaceOneAsync(a => a.Id == account.Id, account);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accounts.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Account account)
        {
            await _accounts.InsertOneAsync(account);
        }
    }
}