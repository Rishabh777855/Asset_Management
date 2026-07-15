using AssetManagementSystem.Application.DTOs.Auth;
using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class EmployeeController(IEmployeeService employeeService, IAuthService authService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync(CancellationToken cancellationToken)
    {
        var result = await employeeService.GetAllEmployeesAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await employeeService.GetEmployeeByIdAsync(id, cancellationToken);   // null logic remaining

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken)
    {
        await employeeService.CreateEmployeeAsync(createEmployeeDto, cancellationToken);

        return Ok("Employee Created Successfully");
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(loginDto, cancellationToken);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
    {
        var result = await authService.RefreshTokenAsync(refreshTokenDto, cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken)
    {
        await employeeService.UpdateEmployeeAsync(id, updateEmployeeDto, cancellationToken);

        return Ok("Employee Updated Successfully");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        await employeeService.DeleteEmployeeAsync(id, cancellationToken);

        return NoContent();
    }

}