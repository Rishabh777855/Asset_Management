using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetRepository(ApplicationDbContext context) : Repository<Asset>(context), IAssetRepository
{
     public IQueryable<Asset> GetAllAssetsWithCategoryAsync()
    {
        return context.Assets
            .Include(a => a.AssetCategory);
    }

    public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync(CancellationToken cancellationToken)
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .Where(a =>a.IsActive && a.Status == AssetStatus.Available)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .Where(a =>a.IsActive && a.AssetCategoryId == categoryId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Asset?> GetAssetWithCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Assets
            .Include(a => a.AssetCategory)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}

