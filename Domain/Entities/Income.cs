using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Income : Transaction
    {
        public Income(string description, decimal amount, DateTime date, string category, Guid accountId)
            : base(description, amount, date, category, accountId)
        {
        }
    }
}
