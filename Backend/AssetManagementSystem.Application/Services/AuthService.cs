using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Application.DTOs.Auth;
using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Helper;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AuthService(IEmployeeRepository employeeRepository, IJwtService jwtService, IRefreshTokenService refreshTokenService, IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByEmailAsync(loginDto.Email, cancellationToken);

        if (employee == null)
            throw new UnauthorizedException("Employee doesn't exsist");

        if (!employee.IsActive)
            throw new UnauthorizedException("Employee Account is not active");

        var isValidPassword = PasswordHash.VerifyPassword(loginDto.Password, employee.PasswordHash!);

        if (!isValidPassword)
            throw new UnauthorizedException("Enter a valid password");

        var token = jwtService.GenerateToken(employee);

        var refreshToken = refreshTokenService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            EmployeeId = employee.Id,
            Token = refreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(1),
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false
        };

        await refreshTokenRepository.AddAsync(refreshTokenEntity, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponseDto
        {
            Token = token,
            RefreshToken = refreshToken,
            EmployeeName = $"{employee.FirstName} {employee.LastName}",
            Email = employee.Email
        };
    }
    public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
    {
        var storedToken = await refreshTokenRepository.GetByTokenAsync(refreshTokenDto.RefreshToken, cancellationToken);

        if (storedToken == null)
            throw new UnauthorizedException("Invalid refresh token.");

        if (storedToken.IsRevoked)
            throw new UnauthorizedException("Refresh token has been revoked.");

        if (storedToken.ExpiryDate <= DateTime.UtcNow)
            throw new UnauthorizedException("Refresh token has expired.");

        var employee = storedToken.Employee;

        var newAccessToken = jwtService.GenerateToken(employee);

        var newRefreshToken = refreshTokenService.GenerateRefreshToken();

        storedToken.IsRevoked = true;

        await refreshTokenRepository.UpdateAsync(storedToken, cancellationToken);

        var refreshTokenEntity = new RefreshToken
        {
            EmployeeId = employee.Id,
            Token = newRefreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(1),
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false
        };

        await refreshTokenRepository.AddAsync(refreshTokenEntity, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponseDto
        {
            Token = newAccessToken,
            RefreshToken = newRefreshToken,
            EmployeeName = $"{employee.FirstName} {employee.LastName}",
            Email = employee.Email
        };
    }
}