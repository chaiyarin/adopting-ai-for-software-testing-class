using Employee.API.Models;
using Employee.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employees> _employees = new()
    {
        new Employees { Id = 1, Name = "John Doe", Age = 30, Position = "Developer" },
        new Employees { Id = 2, Name = "Jane Smith", Age = 28, Position = "QA Engineer" }
    };

    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public ActionResult<Employees> GetEmployeeById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employees>> GetAllEmployees()
    {
        return Ok(_employees);
    }

    [HttpPost]
    public ActionResult AddEmployee([FromBody] Employees employee)
    {
        if (_employeeService.AddEmployee(employee))
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        return BadRequest();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEmployee(int id, [FromBody] Employees employee)
    {
        if (_employeeService.UpdateEmployee(id, employee))
            return Ok();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        if (_employeeService.DeleteEmployee(id))
            return NoContent();
        return NotFound();
    }
}
