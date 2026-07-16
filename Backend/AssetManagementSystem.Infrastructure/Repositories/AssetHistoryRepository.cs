using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetHistoryRepository(ApplicationDbContext context) : Repository<AssetHistory>(context), IAssetHistoryRepository
{
    public async Task<IEnumerable<AssetHistory>> GetAssetHistoriesAsync(Guid assetId, CancellationToken cancellationToken)
    {
        return await context.AssetHistories
            .Include(h => h.Employee)
            .Include(h => h.Asset)
            .Where(h => h.AssetId == assetId)
            .OrderBy(h => h.ActionDate)
            .ToListAsync(cancellationToken);
    }
}