using AssetManagementSystem.Application.DTOs.Employee;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAuthService
{
    Task<bool> LoginAsync(LoginDto loginDto);
}