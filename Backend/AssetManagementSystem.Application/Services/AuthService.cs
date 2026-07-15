using AssetManagementSystem.Application.DTOs;
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
}