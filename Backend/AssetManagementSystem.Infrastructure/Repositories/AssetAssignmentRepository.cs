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
            .Include(a => a.Employee)
            .Include(a => a.Asset)
            .FirstOrDefaultAsync(a =>
                a.AssetId == assetId &&
                (a.Status == AssignmentStatus.Active || 
                 a.Status == AssignmentStatus.Returned));
    }

    public async Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(Guid employeeId)
    {
        return await context.AssetAssignments
            .Include(a => a.Employee)
            .Include(a => a.Asset)
            .Where(a => a.EmployeeId == employeeId)
            .ToListAsync();
    }
}