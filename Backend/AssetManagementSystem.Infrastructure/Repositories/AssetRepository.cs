using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetRepository(ApplicationDbContext context) : Repository<Asset>(context), IAssetRepository<Asset>
{
    public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync()
    {
        return await context.Assets
            .Where(a => a.Status == AssetStatus.Available)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId)
    {
        return await context.Assets
            .Where(a => a.AssetCategoryId == categoryId)
            .ToListAsync();
    }
}

