using AssetManagementSystem.Application.DTOs.Employee;
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
           return false;

        if (!employee.IsActive)
            return false;

        var isValidPassword = PasswordHash.VerifyPassword(loginDto.Password, employee.PasswordHash!);

        if (!isValidPassword)
            return false;

        return true;
    }
}