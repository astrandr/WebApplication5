using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentEmployee>>> Get()
        {
            _logger.LogInformation("Controller: Get all department employees");
            var list = await _employeeService.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentEmployee>> Get(int id)
        {
            _logger.LogInformation("Controller: Get department employee by id {Id}", id);
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentEmployee>> Create(CreateDepartmentEmployeeRequest request)
        {
            _logger.LogInformation("Controller: Create department employee {Employee}", request.Employee);
            var created = await _employeeService.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentEmployeeRequest request)
        {
            _logger.LogInformation("Controller: Update department employee id {Id}", id);
            var isUpdated = await _employeeService.UpdateAsync(id, request);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Controller: Delete department employee id {Id}", id);
            var isDeleted = await _employeeService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
