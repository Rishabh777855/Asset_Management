using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository(ApplicationDbContext context): Repository<Employee>(context), IEmployeeRepository
{
     public async Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Employees
            .FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
    }

    public async Task<Employee?> GetEmployeeWithAssetsAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return await context.Employees
            .Include(e => e.AssetAssignments)
            .ThenInclude(a => a.Asset)
            .FirstOrDefaultAsync(e => e.Id == employeeId, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return await context.Employees
            .AnyAsync(e => e.Id == employeeId, cancellationToken);
    }
}
