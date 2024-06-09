using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Interfaces
{
    public interface IPayslipItemCalculatorService
    {
        decimal Calculate(Employee employee);
    }
}
