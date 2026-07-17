using System.Collections;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class AssetAssignmentRepository(ApplicationDbContext context) : Repository<AssetAssignment>(context), IAssetAssignmentRepository
{
    public async Task<AssetAssignment?> GetActiveAssignmentAsync(Guid assetId, CancellationToken cancellationToken)
    {
        return await context.AssetAssignments
            .Include(a => a.Employee)
            .Include(a => a.Asset)
                .ThenInclude(a => a.AssetCategory)
            .FirstOrDefaultAsync(a =>
                a.AssetId == assetId &&
                a.Status == AssignmentStatus.Active, cancellationToken);
    }

    public async Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return await context.AssetAssignments
            .Include(a => a.Employee)
            .Include(a => a.Asset)
                 .ThenInclude(a => a.AssetCategory)
            .Where(a => a.EmployeeId == employeeId)
            .OrderByDescending(a => a.AssignedDate)
            .ToListAsync(cancellationToken);
    }

    public IQueryable<AssetAssignment> GetAllActiveAssignments()
    {
        return context.AssetAssignments
            .Include(a => a.Employee)
            .Include(a => a.Asset)
                .ThenInclude(a => a.AssetCategory)
            .Where(a => a.Status == AssignmentStatus.Active)
            .OrderByDescending(a => a.AssignedDate);
    }
}