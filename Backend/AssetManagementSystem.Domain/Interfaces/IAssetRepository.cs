using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetRepository : IRepository<Asset>
{
    Task<IEnumerable<Asset>> GetAllAssetsWithCategoryAsync();

    Task<IEnumerable<Asset>> GetAvailableAssetsAsync();

    Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId);

    Task<Asset?> GetAssetWithCategoryAsync(Guid id);
}
