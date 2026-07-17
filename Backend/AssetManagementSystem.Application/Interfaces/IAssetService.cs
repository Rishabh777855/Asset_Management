using AssetManagementSystem.Application.DTOs.Asset;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetService
{
    Task<IEnumerable<AssetResponseDto>> GetAllAssetsWithCategoryAsync(AssetFilterDto assetFilterDto, CancellationToken cancellationToken);

    Task<AssetResponseDto?> GetAssetByIdAsync(Guid id, CancellationToken cancellationToken);

     Task<IEnumerable<AssetResponseDto>> GetAvailableAssetsAsync(CancellationToken cancellationToken);

    Task<IEnumerable<AssetResponseDto>> GetAssetsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);

    Task<AssetResponseDto> CreateAssetAsync(CreateAssetDto dto, CancellationToken cancellationToken);

    Task<AssetResponseDto> UpdateAssetAsync(Guid id, UpdateAssetDto dto, CancellationToken cancellationToken);

    Task DeleteAssetAsync(Guid id, CancellationToken cancellationToken);
}