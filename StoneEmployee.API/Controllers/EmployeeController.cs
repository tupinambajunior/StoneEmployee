using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoneEmployee.API.Extensions;
using StoneEmployee.Application.DTO;
using StoneEmployee.Application.Services.Interfaces;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Repositories;

namespace StoneEmployee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerCustom
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDTO dto)
        {
            try
            {
                _logger.LogInformation("Adding a new employee");

                var employee = await _employeeService.Create(dto);

                return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] EmployeeDTO dto)
        {
            try
            {
                _logger.LogInformation("Adding a new employee");

                var employee = await _employeeService.Update(dto, id);

                return OkResponse(employee);
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            _logger.LogInformation("Fetching employee with id {Id}", id);
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                return NotFound();
            }

            return OkResponse(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                _logger.LogInformation("Deleting employee with id {Id}", id);
                await _employeeService.DeleteAsync(id);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            try
            {
                var employee = await _employeeService.GetListAsync();

                return OkResponse(employee);
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }
    }
}
