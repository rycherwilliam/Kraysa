using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid accountId);
        Task UpdateAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
    }
}
