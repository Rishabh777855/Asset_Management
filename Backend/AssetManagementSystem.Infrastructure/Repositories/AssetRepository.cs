using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetRepository(ApplicationDbContext context) : Repository<Asset>(context), IAssetRepository
{
     public async Task<IEnumerable<Asset>> GetAllAssetsWithCategoryAsync()
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync()
    {
        return await context.Assets
            .Where(a => a.Status == AssetStatus.Available)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId)
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .Where(a => a.AssetCategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<Asset?> GetAssetWithCategoryAsync(Guid id)
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}

