using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<Employee?> GetEmployeeWithAssetsAsync(Guid employeeId, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Guid employeeId, CancellationToken cancellationToken);
}