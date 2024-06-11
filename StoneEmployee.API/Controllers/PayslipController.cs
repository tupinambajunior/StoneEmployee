using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoneEmployee.API.Extensions;
using StoneEmployee.Application.Services.Implementations;
using StoneEmployee.Application.Services.Interfaces;

namespace StoneEmployee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayslipController : ControllerCustom
    {
        private readonly IPayslipService _payslipService;
        private readonly ILogger<EmployeeController> _logger;

        public PayslipController(IPayslipService payslipService, ILogger<EmployeeController> logger)
        {
            _payslipService = payslipService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            _logger.LogInformation("Fetching payslip employee with id {Id}", id);
            var employee = await _payslipService.GetPaymentslip(id);

            return OkResponse(employee);
        }
    }
}
