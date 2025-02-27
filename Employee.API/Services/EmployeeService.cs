using Employee.API.Models;

namespace Employee.API.Services;
public class EmployeeService : IEmployeeService
{
    private List<Employees> _employees = new();

    public bool AddEmployee(Employees employee)
    {
        if (employee == null) return false;
        _employees.Add(employee);
        return true;
    }

    public bool UpdateEmployee(int id, Employees employee)
    {
        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing == null) return false;

        existing.Name = employee.Name;
        existing.Age = employee.Age;
        existing.Position = employee.Position;
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null) return false;

        _employees.Remove(employee);
        return true;
    }

    public Employees GetEmployeeById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        return null;
    }
}