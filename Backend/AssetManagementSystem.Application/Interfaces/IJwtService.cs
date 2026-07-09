using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(Employee employee);
}