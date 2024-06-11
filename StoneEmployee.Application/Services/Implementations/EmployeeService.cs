using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using StoneEmployee.Application.DTO;
using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Exceptions;
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
        private readonly IValidator<Employee> _employeeValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger, IValidator<Employee> employeeValidator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _employeeValidator = employeeValidator;
        }

        public async Task<EmployeeDTO> Create(EmployeeDTO dto)
        {
            var employeeByDocument = await _employeeRepository.GetByDocument(dto.Document);

            if (employeeByDocument != null)
                throw new Core.Exceptions.ValidationException("This document is being used by another employee");

            _logger.LogInformation("Adding a new employee");
            var employee = _mapper.Map<Employee>(dto);

            var validationResult = await _employeeValidator.ValidateAsync(employee);

            if(!validationResult.IsValid)
                throw new FluentValidation.ValidationException(validationResult.Errors);

            var employeeId = await _employeeRepository.CreateAsync(employee);

            var employeeDb = await _employeeRepository.GetByIdAsync(employeeId);

            var resultDto = _mapper.Map<EmployeeDTO>(employee);

            return resultDto;
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO dto, string id)
        {
            var employeeDb = await _employeeRepository.GetByIdAsync(id);

            if (employeeDb == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                throw new NotFoundException("Employee not found");
            }

            var employeeByDocument = await _employeeRepository.GetByDocument(dto.Document, id);

            if (employeeByDocument != null)
                throw new Core.Exceptions.ValidationException("This document is being used by another employee");

            _logger.LogInformation("Adding a new employee");
            _mapper.Map(dto, employeeDb);

            var validationResult = await _employeeValidator.ValidateAsync(employeeDb);

            if (!validationResult.IsValid)
                throw new FluentValidation.ValidationException(validationResult.Errors);

            await _employeeRepository.SaveChangesAsync();

            var resultDto = _mapper.Map<EmployeeDTO>(employeeDb);

            return resultDto;
        }

        public async Task<EmployeeDTO> GetByIdAsync(string id)
        {
            _logger.LogInformation("Fetching employee with id {Id}", id);
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                throw new NotFoundException("Employee not found");
            }

            var dto = _mapper.Map<EmployeeDTO>(employee);

            return dto;
        }

        public async Task DeleteAsync(string id)
        {
            _logger.LogInformation("Fetching employee with id {Id}", id);
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                throw new NotFoundException("Employee not found");
            }

            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<List<EmployeeDTO>> GetListAsync()
        {
            _logger.LogInformation("Fetching list of employees");
            var employees = await _employeeRepository.GetListAsync();

            var dto = _mapper.Map<List<EmployeeDTO>>(employees);

            return dto;
        }
    }
}
