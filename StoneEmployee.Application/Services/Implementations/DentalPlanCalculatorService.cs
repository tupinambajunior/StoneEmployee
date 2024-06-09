using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class DentalPlanCalculatorService : IPayslipItemCalculatorService
    {
        private readonly decimal _dentalPlanPrice = 5;

        public decimal Calculate(Employee employee)
        {
            return employee.HasDentalPlan ? _dentalPlanPrice : 0;
        }
    }
}