using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.Mapping;
using Shared.Model.Employee;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region Constractor

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        #region List

        [HttpGet("List")]
        public async Task<IActionResult> List([FromQuery] EmployeePagedQueryViewModel viewModel)
        {
            return Ok(await _employeeService.ListAsync(viewModel.ToDto()));
        }

        #endregion

        #region Create

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EmployeeViewModel viewModel)
        {
            var result = await _employeeService.CreateAsync(viewModel.ToDto());
            return result > 0 ? Ok(true) : BadRequest(false);
        }

        #endregion

        #region Edit

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EmployeeViewModel viewModel)
        {
            var result = await _employeeService.EditAsync(viewModel.ToDto());
            return result > 0 ? Ok(true) : BadRequest(false);
        }

        #endregion

        #region Detail

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _employeeService.GetAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        #endregion

        #region Delete

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return result > 0 ? Ok(true) : NotFound();
        }

        #endregion
    }
}
