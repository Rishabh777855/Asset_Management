using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetAssignmentRepository(ApplicationDbContext context) : Repository<AssetAssignment>(context), IAssetAssignmentRepository
{
    public async Task<AssetAssignment?> GetActiveAssignmentAsync(Guid assetId)
    {
        return await context.AssetAssignments
            .FirstOrDefaultAsync(a =>
                a.AssetId == assetId &&
                a.Status == AssignmentStatus.Active);
    }

    public async Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(Guid employeeId)
    {
        return await context.AssetAssignments
            .Where(a => a.EmployeeId == employeeId)
            .ToListAsync();
    }
}