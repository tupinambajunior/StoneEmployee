using Microsoft.EntityFrameworkCore;
using StoneEmployee.Infrastructure.Database;

namespace StoneEmployee.API.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("EmployeeConnectionString");
            services.AddDbContext<PgContext>(options => options.UseNpgsql(connectionString));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
