using AssetManagementSystem.Application.DTOs;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetHistoryService
{
    Task<IEnumerable<AssetHistoryResponseDto>> GetAssetHistoryAsync(Guid assetId, CancellationToken cancellationToken);
}