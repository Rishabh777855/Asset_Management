using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetRepository<T> : IRepository<Asset>
{
    Task<IEnumerable<Asset>> GetAvailableAssetsAsync();

    Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId);

   // Task<Asset?> GetAssetWithCategoryAsync(Guid id);
}
