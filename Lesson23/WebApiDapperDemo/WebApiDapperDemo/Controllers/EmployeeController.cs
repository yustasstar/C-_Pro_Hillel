using Microsoft.AspNetCore.Mvc;
using WebApiDapperDemo.Models;
using WebApiDapperDemo.Services;

namespace WebApiDapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.GetEmployeeList());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            return Ok(await _employeeService.CreateEmployee(employee));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            return Ok(await _employeeService.UpdateEmployee(employee));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok(await _employeeService.DeleteEmployee(id));
        }
    }
}
