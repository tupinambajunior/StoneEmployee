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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateEmployeeDTO dto)
        {
            try
            {
                _logger.LogInformation("Adding a new employee");

                var employeeId = await _employeeService.Create(dto);

                return CreatedAtAction(nameof(Get), new { id = employeeId }, dto);
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                _logger.LogInformation("Fetching employee with id {Id}", id);
                var employee = await _employeeRepository.GetByIdAsync(id);

                if (employee == null)
                {
                    _logger.LogWarning("Employee with id {Id} not found", id);
                    return NotFound();
                }

                return OkResponse(employee);
            }
            catch (Exception ex)
            {
                return HandleException(ex, _logger);
            }
        }
    }
}
