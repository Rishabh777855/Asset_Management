using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AssetManagementSystem.Infrastructure.Authentication;

public class JwtService(IConfiguration configuration) : IJwtService
{
    public string GenerateToken(Employee employee)
    {
        var key = configuration["Jwt:Key"]!;
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var expiry = Convert.ToDouble(configuration["Jwt:ExpiryInMinutes"]);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, employee.Email),
            new(JwtRegisteredClaimNames.Name,
                $"{employee.FirstName} {employee.LastName}")
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(expiry),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}