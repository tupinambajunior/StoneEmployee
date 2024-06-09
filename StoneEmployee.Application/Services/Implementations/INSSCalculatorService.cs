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
    public class INSSCalculatorService : IPayslipItemCalculatorService
    {
        private readonly List<INSSTaxRate> _inssRates = new List<INSSTaxRate>
        {
            new INSSTaxRate { MinSalary = 0.00m, MaxSalary = 1045.00m, Rate = 7.50m },
            new INSSTaxRate { MinSalary = 1045.01m, MaxSalary = 2089.60m, Rate = 9.00m },
            new INSSTaxRate { MinSalary = 2089.61m, MaxSalary = 3134.40m, Rate = 12.00m },
            //new INSSTaxRate { MinSalary = 3134.41m, MaxSalary = 6101.06m, Rate = 14.00m }
            new INSSTaxRate { MinSalary = 3134.41m, MaxSalary = decimal.MaxValue, Rate = 14.00m }
        };

        public decimal Calculate(Employee employee)
        {
            var rate = _inssRates.FirstOrDefault(r => employee.GrossSalary >= r.MinSalary && employee.GrossSalary <= r.MaxSalary)?.Rate ?? 0;
            return Math.Round(employee.GrossSalary * (rate / 100), 2);
        }
    }
}