using StoneEmployee.Core.Repositories;
using StoneEmployee.Infrastructure.Database.Repositories;

namespace StoneEmployee.API.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
