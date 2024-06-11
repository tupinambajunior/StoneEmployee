using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class INSSCalculatorServiceTests
    {
        private readonly INSSCalculatorService _service;

        public INSSCalculatorServiceTests()
        {
            _service = new INSSCalculatorService();
        }

        [Theory]

        //TAX RATE: 7,5%
        [InlineData(1_000, 75)]
        [InlineData(1_045, 78.38)]

        //TAX RATE: 9%
        [InlineData(1_045.01, 94.05)]
        [InlineData(1_500, 135)]
        [InlineData(2_089.60, 188.06)]

        //TAX RATE: 12%
        [InlineData(2_089.61, 250.75)]
        [InlineData(2_500, 300)]
        [InlineData(3_134.40, 376.13)]

        //TAX RATE 14%
        [InlineData(3_134.41, 438.82)]
        [InlineData(3_500, 490)]
        [InlineData(6_101.06, 854.15)]
        [InlineData(10_000, 1_400)]
        public void Calculate_ShouldCalculateCorrectly(decimal grossSalary, decimal expectedTaxRate)
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
                                    hasTransportationVouchers: false
                                    );

            var currentTaxRate = _service.Calculate(employee);

            Assert.Equal(expectedTaxRate, currentTaxRate);
        }
    }
}
