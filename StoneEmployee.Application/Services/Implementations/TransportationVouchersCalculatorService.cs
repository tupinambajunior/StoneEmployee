using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class TransportationVouchersCalculatorService : IPayslipItemCalculatorService
    {
        private readonly decimal _transportationVouchersTaxRate = 6;
        private readonly decimal _MinGrossSalary = 1500;

        public decimal Calculate(Employee employee)
        {
            if (!employee.HasTransportationVouchers || employee.GrossSalary < _MinGrossSalary)
                return 0;

            decimal transportationVouchers = employee.GrossSalary * (_transportationVouchersTaxRate / 100);

            return transportationVouchers;
        }
    }
}
