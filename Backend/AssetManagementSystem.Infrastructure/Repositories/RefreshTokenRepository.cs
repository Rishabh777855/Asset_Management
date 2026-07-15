using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class RefreshTokenRepository(ApplicationDbContext context)
    : Repository<RefreshToken>(context), IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken)
    {
        return await context.RefreshTokens
            .Include(r => r.Employee)
            .FirstOrDefaultAsync(r => r.Token == token, cancellationToken);
    }

    public async Task<IEnumerable<RefreshToken>> GetEmployeeRefreshTokensAsync(
        Guid employeeId,
        CancellationToken cancellationToken)
    {
        return await context.RefreshTokens
            .Where(r => r.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }
}