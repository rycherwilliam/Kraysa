using Application.Models;
using Domain.Entities;

namespace Application.Adapters
{
    public static class TransactionAdapter
    {
        public static Transaction ToDomain(TransactionDto dto)
        {
            return dto switch
            {
                IncomeDto incomeDto => new Income(incomeDto.Description, incomeDto.Amount, incomeDto.Date, incomeDto.Category, incomeDto.AccountId),
                OutcomeDto outcomeDto => new Outcome(outcomeDto.Description, outcomeDto.Amount, outcomeDto.Date, outcomeDto.Category, outcomeDto.Installments, outcomeDto.AccountId),
                _ => throw new ArgumentException("Invalid TransactionDto type.")
            };
        }
    }
}
