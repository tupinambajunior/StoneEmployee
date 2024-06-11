using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Application.Services.Interfaces;

namespace StoneEmployee.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPayslipItemCalculatorService, INSSCalculatorService>();
            services.AddScoped<IPayslipItemCalculatorService, IRPFCalculatorService>();
            services.AddScoped<IPayslipItemCalculatorService, FGTSCalculatorService>();
            services.AddScoped<IPayslipItemCalculatorService, TransportationVouchersCalculatorService>();
            services.AddScoped<IPayslipItemCalculatorService, HealthPlanCalculatorService>();
            services.AddScoped<IPayslipItemCalculatorService, DentalPlanCalculatorService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
