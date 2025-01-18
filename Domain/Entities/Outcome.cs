using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{    public class Outcome : Transaction
    {
        public int Installments { get; private set; }

        public Outcome(string description, decimal amount, DateTime date, string category, int installments, Guid accountId)
            : base(description, amount, date, category, accountId)
        {
            if (installments <= 0)
                throw new ArgumentException("Installments must be greater than zero.");

            Installments = installments;
        }
    }
}
