using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class TransportationVouchersCalculatorServiceTests
    {
        private readonly TransportationVouchersCalculatorService _service;

        public TransportationVouchersCalculatorServiceTests()
        {
            _service = new TransportationVouchersCalculatorService();
        }

        [Theory]
        [InlineData(true, 1_000, 0)]
        [InlineData(true, 1_499.99, 0)]
        [InlineData(true, 1_500, 90)]
        [InlineData(true, 2_000, 120)]
        [InlineData(false, 2_000, 0)]
        public void Calculate_ShouldCalculateCorrectly(bool hasTransportationVouchers, decimal grossSalary, decimal expectedTaxRate)
        {
            var employee = new Employee(
                                    id: Guid.NewGuid().ToString(),
                                    firstName: "",
                                    lastName: "",
                                    document: "94498458087",
                                    sector: "",
                                    grossSalary: grossSalary,
                                    admissionDate: DateTime.Now,
                                    hasDentalPlan: false,
                                    hasHealthPlan: false,
                                    hasTransportationVouchers: hasTransportationVouchers
                                    );

            var currentTaxRate = _service.Calculate(employee);

            Assert.Equal(expectedTaxRate, currentTaxRate);
        }
    }
}