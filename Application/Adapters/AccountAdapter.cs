using Application.Models;
using Domain.Entities;

namespace Application.Adapters
{
    public static class AccountAdapter
    {
        public static Account ToDomain(AccountDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Account name cannot be empty.");

            return new Account(dto.Name, dto.InitialBalance);
        }
    }
}
