using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mapper;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AssetHistoryService(IAssetHistoryRepository assetHistoryRepository, IAssetRepository assetRepository) : IAssetHistoryService
{
    public async Task<IEnumerable<AssetHistoryResponseDto>> GetAssetHistoryAsync(Guid assetId, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetByIdAsync(assetId, cancellationToken);

        if (asset == null)
            throw new NotFoundException("Asset not found.");

        var history = await assetHistoryRepository.GetAssetHistoriesAsync(assetId, cancellationToken);

        return history.Select(AssetHistoryMapper.ToResponseDto);
    }
}