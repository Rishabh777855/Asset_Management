using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{

    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken);

    Task<IEnumerable<RefreshToken>> GetEmployeeRefreshTokensAsync(Guid employeeId, CancellationToken cancellationToken);
}