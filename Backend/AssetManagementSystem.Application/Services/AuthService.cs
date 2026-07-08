using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Helper;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AuthService(IEmployeeRepository employeeRepository) : IAuthService
{
    public async Task<bool> LoginAsync(LoginDto loginDto)
    {
        var employee = await employeeRepository.GetByEmailAsync(loginDto.Email);

        if(employee == null)
           throw new UnauthorizedException("Employee doesn't exsist");

        if (!employee.IsActive)
            throw new UnauthorizedException("Employee Account is not active");

        var isValidPassword = PasswordHash.VerifyPassword(loginDto.Password, employee.PasswordHash!);

        if (!isValidPassword)
            throw new UnauthorizedException("Enter a valid password");

        return true;
    }
}