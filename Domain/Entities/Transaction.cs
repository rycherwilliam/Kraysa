using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Transaction
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public decimal Amount { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Category { get; protected set; }
        public Guid AccountId { get; protected set; }

        protected Transaction(string description, decimal amount, DateTime date, string category, Guid accountId)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (accountId == Guid.Empty)
                throw new ArgumentException("AccountId cannot be empty.");

            Id = Guid.NewGuid();
            Description = description;
            Amount = amount;
            Date = date;
            Category = category;
            AccountId = accountId;
        }
    }
}
