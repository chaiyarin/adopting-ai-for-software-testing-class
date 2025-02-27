using Employee.API.Controllers;
using Employee.API.Models;
using Employee.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Employee.API.Test;

public class EmployeeControllerTest
{

    private readonly Mock<IEmployeeService> _mockService;
    private readonly EmployeeController _controller;

    public EmployeeControllerTest()
    {
        _mockService = new Mock<IEmployeeService>();
        _controller = new EmployeeController(_mockService.Object);
    }

    [Fact]
    public void GetEmployeeById_ReturnsCorrectEmployee()
    {
        // Arrange
        var controller = new EmployeeController(_mockService.Object);

        // Act
        var result = controller.GetEmployeeById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var employee = Assert.IsType<Employees>(actionResult.Value);
        Assert.Equal(1, employee.Id);
        Assert.Equal("John Doe", employee.Name);
    }

    [Fact]
    public void GetAllEmployees_ReturnsAllEmployees()
    {
        // Arrange
        var controller = new EmployeeController(_mockService.Object);

        // Act
        var result = controller.GetAllEmployees();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var employees = Assert.IsType<List<Employees>>(actionResult.Value);
        Assert.Equal(2, employees.Count);
    }

    [Fact]
    public void AddEmployee_ReturnsCreatedAtAction()
    {
        // Arrange
        var newEmployee = new Employees { Id = 3, Name = "Alice", Age = 25, Position = "HR" };
        _mockService.Setup(s => s.AddEmployee(newEmployee)).Returns(true);

        // Act
        var result = _controller.AddEmployee(newEmployee);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetEmployeeById", actionResult.ActionName);
    }

    [Fact]
    public void UpdateEmployee_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var updatedEmployee = new Employees { Id = 1, Name = "Updated Name", Age = 32, Position = "Senior Dev" };
        _mockService.Setup(s => s.UpdateEmployee(1, updatedEmployee)).Returns(true);

        // Act
        var result = _controller.UpdateEmployee(1, updatedEmployee);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void DeleteEmployee_CallsServiceMethodOnce()
    {
        // Arrange
        _mockService.Setup(s => s.DeleteEmployee(1)).Returns(true);

        // Act
        var result = _controller.DeleteEmployee(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _mockService.Verify(s => s.DeleteEmployee(1), Times.Once);
    }
}
