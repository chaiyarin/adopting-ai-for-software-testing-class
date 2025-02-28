using Employee.API.Models;
using Employee.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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

    [HttpGet("unsafe/{name}")]
    public ActionResult<Employees> GetEmployeeByName(string name)
    {
        using (var connection = new SqlConnection("Server=myServer;Database=myDB;User Id=myUser;Password=myPass;"))
        {
            connection.Open();
            var command = new SqlCommand($"SELECT * FROM Employees WHERE Name = '{name}'", connection);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Ok(new Employees
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Age = (int)reader["Age"],
                    Position = reader["Position"].ToString()
                });
            }
            return NotFound();
        }
    }

    private const string SecretKey = "supersecretkey123!"; 

    [HttpGet("{id}")]
    public ActionResult<Employees> GetEmployeeById(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employees>> GetAllEmployees()
    {
        return Ok(_employees);
    }

    // 🚨 **Duplicate Code**
    // The same `GetAllEmployees` method repeated unnecessarily
    [HttpGet("all")]
    public ActionResult<IEnumerable<Employees>> GetAllEmployeesDuplicate()
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