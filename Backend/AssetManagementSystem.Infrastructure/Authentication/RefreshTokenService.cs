using System.Security.Cryptography;
using AssetManagementSystem.Application.Interfaces;

namespace AssetManagementSystem.Infrastructure.Services;

public class RefreshTokenService : IRefreshTokenService
{
    public string GenerateRefreshToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);

        return Convert.ToBase64String(randomBytes);
    }
}