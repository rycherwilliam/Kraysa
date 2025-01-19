using Application.UseCases;
using Application.UseCases.Interfaces;
using Application.Repositories.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Infrastructure.Configurations;

namespace DI
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateAccountUseCase, CreateAccountUseCase>();
            services.AddScoped<IGetAccountUseCase, GetAccountUseCase>();
            services.AddScoped<IUpdateAccountBalanceUseCase, UpdateAccountBalanceUseCase>();
        
            services.AddScoped<IGetTransactionUseCase, GetTransactionsUseCase>();
            services.AddScoped<IAddTransactionUseCase, AddTransactionUseCase>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();            

            services.Configure<MongoDbConfig>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<MongoDbConfig>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                return new MongoDbConfig(config);
            });

            return services;          
        }
    }
}
