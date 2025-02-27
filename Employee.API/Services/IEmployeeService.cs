using Employee.API.Models;

namespace Employee.API.Services
{
    public interface IEmployeeService
    {
        public Employees GetEmployeeById(int id);
        public bool AddEmployee(Employees employee);
        public bool UpdateEmployee(int id, Employees employee);
        public bool DeleteEmployee(int id);
    }
}