using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Application.DTOs.Employee;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
}