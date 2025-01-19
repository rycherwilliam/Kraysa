using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Interfaces
{
    public interface IGetAccountUseCase
    {        
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(Guid accountId);
    }
}
