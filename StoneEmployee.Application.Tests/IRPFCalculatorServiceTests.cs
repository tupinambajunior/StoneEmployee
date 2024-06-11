using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class IRPFCalculatorServiceTests
    {
        private readonly IRPFCalculatorService _service;

        public IRPFCalculatorServiceTests()
        {
            _service = new IRPFCalculatorService();
        }

        [Theory]

        //TAX RATE: 0%
        [InlineData(1_000, 0)]
        [InlineData(1_903.98, 0)]

        //TAX RATE: 7.5%
        [InlineData(1_903.99, 142.80)]
        [InlineData(2_000, 142.80)]
        [InlineData(2_826.65, 142.80)]

        //TAX RATE: 15%
        [InlineData(2_826.66, 354.80)]
        [InlineData(3_000, 354.80)]
        [InlineData(3_751.05, 354.80)]

        //TAX RATE 22.5%
        [InlineData(3_751.06, 636.13)]
        [InlineData(3_800, 636.13)]
        [InlineData(4_664.68, 636.13)]

        //TAX RATE 27.5%
        [InlineData(4_664.69, 869.36)]
        [InlineData(4_700, 869.36)]
        [InlineData(5_000, 869.36)]
        [InlineData(10_000, 869.36)]

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
