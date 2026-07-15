using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IAssetRepository : IRepository<Asset>
{
    Task<IEnumerable<Asset>> GetAllAssetsWithCategoryAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Asset>> GetAvailableAssetsAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);

    Task<Asset?> GetAssetWithCategoryAsync(Guid id, CancellationToken cancellationToken);
}
