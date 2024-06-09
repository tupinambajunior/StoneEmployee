﻿using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Tests
{
    public class HealthPlanCalculatorServiceTests
    {
        private readonly HealthPlanCalculatorService _service;

        public HealthPlanCalculatorServiceTests()
        {
            _service = new HealthPlanCalculatorService();
        }

        [Theory]
        [InlineData(true, 10)]
        [InlineData(false, 0)]
        public void Calculate_ShouldCalculateCorrectly(bool hasHealthPlan, decimal expectedTaxRate)
        {
            var employee = new Employee { HasHealthPlan = hasHealthPlan };
            var currentTaxRate = _service.Calculate(employee);

            Assert.Equal(expectedTaxRate, currentTaxRate);
        }
    }
}