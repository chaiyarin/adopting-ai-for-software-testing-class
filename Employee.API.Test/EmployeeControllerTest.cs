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

}
