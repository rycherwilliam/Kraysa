using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Interfaces
{
    public interface IAddTransactionUseCase
    {
        Task ExecuteAsync(TransactionDto transactionDto);
    }
}
