using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class HealthPlanCalculatorService : IPayslipItemCalculatorService
    {
        private readonly decimal _healthPlanPrice = 10;

        public decimal Calculate(Employee employee)
        {
            return employee.HasHealthPlan ? _healthPlanPrice : 0;
        }
    }
}
