using AssetManagementSystem.Application.DTOs.Asset;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetService
{
    Task<IEnumerable<AssetResponseDto>> GetAllAssetsAsync();

    Task<AssetResponseDto?> GetAssetByIdAsync(Guid id);

    // Task<IEnumerable<AssetResponseDto>> GetAvailableAssetsAsync();

    Task<IEnumerable<AssetResponseDto>> GetAssetsByCategoryAsync(Guid categoryId);

    Task<AssetResponseDto> CreateAssetAsync(CreateAssetDto dto);

    Task<AssetResponseDto> UpdateAssetAsync(Guid id, UpdateAssetDto dto);
    
    Task DeleteAssetAsync(Guid id);
}