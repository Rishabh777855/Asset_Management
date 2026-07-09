using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController(IEmployeeService employeeService, IAuthService authService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employee = await employeeService.GetAllEmployeesAsync();

        return Ok(employee);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id);   // null logic remaining

        return Ok(employee);
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        await employeeService.CreateEmployeeAsync(createEmployeeDto);

        return Ok("Employee Created Successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var authenticated = await authService.LoginAsync(loginDto);

        return Ok(authenticated);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
    {
        await employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);

        return Ok("Employee Updated Successfully");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await employeeService.DeleteEmployeeAsync(id);

        return NoContent();
    }

}