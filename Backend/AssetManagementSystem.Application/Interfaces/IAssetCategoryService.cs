using AssetManagementSystem.Application.DTOs;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetCategoryService
{
    Task<IEnumerable<AssetCategoryResponseDto>> GetAllAssetCategoriesAsync(CancellationToken cancellationToken);
}