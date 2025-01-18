using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString, string databaseName)
        {
            // Call Infrastructure service registration
            services.AddInfrastructureServices(connectionString, databaseName);

            // Register any Application-specific services or Use Cases here (if necessary)

            return services;
        }
    }
}
