using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OutcomeDto : TransactionDto
    {
        public int Installments { get; set; } // Specific to Outcome
    }
}
