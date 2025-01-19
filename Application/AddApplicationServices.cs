using Application.UseCases.Interfaces;
using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationUseCases(
            this IServiceCollection services)
        {
            // Account
            services.AddScoped<ICreateAccountUseCase, CreateAccountUseCase>();            
            services.AddScoped<IGetAccountUseCase, GetAccountUseCase>();
            services.AddScoped<IUpdateAccountBalanceUseCase, UpdateAccountBalanceUseCase>();

            // Transaction
            services.AddScoped<IGetTransactionUseCase, GetTransactionsUseCase>();
            services.AddScoped<IAddTransactionUseCase, AddTransactionUseCase>();
        }
    }
}
