using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class DentalPlanCalculatorServiceTests
    {
        private readonly DentalPlanCalculatorService _service;

        public DentalPlanCalculatorServiceTests()
        {
            _service = new DentalPlanCalculatorService();
        }

        [Theory]
        [InlineData(true, 5)]
        [InlineData(false, 0)]
        public void Calculate_ShouldCalculateCorrectly(bool hasDentalPlan, decimal expectedTaxRate)
        {
            var employee = new Employee(
                                    id: Guid.NewGuid().ToString(),
                                    firstName: "",
                                    lastName: "",
                                    document: "94498458087",
                                    sector: "",
                                    grossSalary: 0,
                                    admissionDate: DateTime.Now,
                                    hasDentalPlan: hasDentalPlan,
                                    hasHealthPlan: false,
                                    hasTransportationVouchers: false
                                    );

            var currentTaxRate = _service.Calculate(employee);

            Assert.Equal(expectedTaxRate, currentTaxRate);
        }
    }
}
