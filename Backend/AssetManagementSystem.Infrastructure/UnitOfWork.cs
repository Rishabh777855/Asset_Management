using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Infrastructure;
public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}