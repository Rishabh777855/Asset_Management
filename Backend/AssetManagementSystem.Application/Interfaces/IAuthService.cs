using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Application.DTOs.Auth;
using AssetManagementSystem.Application.DTOs.Employee;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken);

    Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken);
}