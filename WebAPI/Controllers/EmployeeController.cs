using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.Mapping;
using Shared.Model.Employee;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : ApiControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] EmployeePagedQueryViewModel viewModel)
        {
            return Ok(await _employeeService.ListAsync(viewModel.ToDto()));
        }
    }
}
