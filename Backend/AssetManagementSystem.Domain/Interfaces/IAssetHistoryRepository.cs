using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetHistoryRepository : IRepository<AssetHistory>
{
    Task<IEnumerable<AssetHistory>> GetAssetHistoriesAsync (Guid assetId, CancellationToken cancellationToken);
}