using Application.Repositories.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class InfrastructureServiceFactory
    {
        public static IServiceCollection RegisterInfrastructureServices(
            IServiceCollection services,
            string connectionString,
            string databaseName)
        {
            var mongoConfig = new MongoDbConfig(connectionString, databaseName);
            services.AddSingleton(mongoConfig);

            // Register repositories
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
