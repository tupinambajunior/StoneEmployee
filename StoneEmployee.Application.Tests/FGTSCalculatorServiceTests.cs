using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class FGTSCalculatorServiceTests
    {
        private readonly FGTSCalculatorService _service;

        public FGTSCalculatorServiceTests()
        {
            _service = new FGTSCalculatorService();
        }

        [Theory]
        [InlineData(1_000, 80)]
        [InlineData(1_903.98, 152.32)]
        [InlineData(2_826.65, 226.13)]
        [InlineData(3_751.05, 300.08)]
        [InlineData(4_664.68, 373.17)]
        [InlineData(5_000, 400)]
        public void Calculate_ShouldCalculateCorrectly(decimal grossSalary, decimal expectedTaxRate)
        {
            var employee = new Employee(
                                    id: Guid.NewGuid().ToString(),
                                    firstName: "",
                                    lastName: "",
                                    document: "",
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