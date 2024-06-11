using Microsoft.Extensions.Logging;
using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Exceptions;
using StoneEmployee.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class PayslipService : IPayslipService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<PayslipService> _logger;
        private readonly IEnumerable<IPayslipItemCalculatorService> _paymentSlipItemsCalculator;

        public PayslipService(IEmployeeRepository employeeRepository, ILogger<PayslipService> logger, IEnumerable<IPayslipItemCalculatorService> paymentSlipItemsCalculator)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _paymentSlipItemsCalculator = paymentSlipItemsCalculator;
        }

        public async Task<PaySlip> GetPaymentslip(string employeeId)
        {
            _logger.LogInformation("Fetching paymentslip for employee with id {Id}", employeeId);

            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", employeeId);
                throw new NotFoundException("Employee not found");
            }

            var paymentSlip = new PaySlip();
            paymentSlip.GrossSalary = employee.GrossSalary;
            paymentSlip.ReferenceMonth = DateTime.Now.Date;
            paymentSlip.PayslipItems = new List<PayslipItem>();

            paymentSlip.PayslipItems.Add(new PayslipItem
            {
                Type = Core.Enumerators.PayslipItemType.remuneration,
                Value = employee.GrossSalary,
                Description = "Gross Salary"
            });


            foreach (var calculator in _paymentSlipItemsCalculator)
            {
                var discountValue = calculator.Calculate(employee);
                paymentSlip.TotalDiscount += (discountValue * -1);
                paymentSlip.PayslipItems.Add(new PayslipItem
                {
                    Type = Core.Enumerators.PayslipItemType.discount,
                    Value = discountValue,
                    Description = calculator.GetType().Name.Replace("CalculatorService", "")
                });
            }

            paymentSlip.NetSalary = employee.GrossSalary + paymentSlip.TotalDiscount;


            return paymentSlip;
        }
    }
}
