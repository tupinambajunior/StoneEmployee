using AutoMapper;
using Microsoft.Extensions.Logging;
using StoneEmployee.Application.DTO;
using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Create(CreateEmployeeDTO dto)
        {
            var employeeByDocument = await _employeeRepository.GetByDocument(dto.Document);

            if (employeeByDocument != null)
                throw new ValidationException("This document is being used by another employee");

            _logger.LogInformation("Adding a new employee");
            var employee = _mapper.Map<Employee>(dto);

            var employeeId = await _employeeRepository.CreateAsync(employee);

            return employeeId;
        }

        public async Task<Employee> Get(string id)
        {
            _logger.LogInformation("Fetching employee with id {Id}", id);
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                throw new Exception("Employee not found");
            }

            return employee;
        }
    }
}
