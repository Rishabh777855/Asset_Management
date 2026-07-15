using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController(IEmployeeService employeeService, IAuthService authService) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
    {
        var employee = await employeeService.GetAllEmployeesAsync(cancellationToken);

        return Ok(employee);
    }

    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id, cancellationToken);   // null logic remaining

        return Ok(employee);
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken)
    {
        await employeeService.CreateEmployeeAsync(createEmployeeDto, cancellationToken);

        return Ok("Employee Created Successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var authenticated = await authService.LoginAsync(loginDto, cancellationToken);

        return Ok(authenticated);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken)
    {
        await employeeService.UpdateEmployeeAsync(id, updateEmployeeDto, cancellationToken);

        return Ok("Employee Updated Successfully");
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await employeeService.DeleteEmployeeAsync(id, cancellationToken);

        return NoContent();
    }

}