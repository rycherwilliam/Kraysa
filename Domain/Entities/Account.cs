using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public List<Guid> SharedWith { get; private set; }

        public Account(string name, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Account name cannot be empty.");

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            Id = Guid.NewGuid();
            Name = name;
            Balance = initialBalance;
            SharedWith = new List<Guid>();
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }

        public void ShareWith(Guid accountId)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            if (!SharedWith.Contains(accountId))
            {
                SharedWith.Add(accountId);
            }
        }

        public void RevokeShare(Guid accountId)
        {
            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            SharedWith.Remove(accountId);
        }
    }
}
