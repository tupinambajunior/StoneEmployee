using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class IRPFCalculatorService : IPayslipItemCalculatorService
    {
        private readonly List<IRPFTaxRate> _irpfRates = new List<IRPFTaxRate>
        {
            new IRPFTaxRate { MinSalary = 0.00m, MaxSalary = 1903.98m, Rate = 0.00m, MaxDeduction = 0.00m },
            new IRPFTaxRate { MinSalary = 1903.99m, MaxSalary = 2826.65m, Rate = 7.50m, MaxDeduction = 142.80m },
            new IRPFTaxRate { MinSalary = 2826.66m, MaxSalary = 3751.05m, Rate = 15.00m, MaxDeduction = 354.80m },
            new IRPFTaxRate { MinSalary = 3751.06m, MaxSalary = 4664.68m, Rate = 22.50m, MaxDeduction = 636.13m },
            new IRPFTaxRate { MinSalary = 4664.69m, MaxSalary = decimal.MaxValue, Rate = 27.50m, MaxDeduction = 869.36m }
        };

        public decimal Calculate(Employee employee)
        {
            var rate = _irpfRates.FirstOrDefault(r => employee.GrossSalary >= r.MinSalary && employee.GrossSalary <= r.MaxSalary);

            if (rate == null)
                return 0;

            decimal irpf = employee.GrossSalary * (rate.Rate / 100);
            return irpf > rate.MaxDeduction ? rate.MaxDeduction : Math.Round(irpf, 2);
        }
    }
}
