using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Domain.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetByEmailAsync(string email);

    Task<Employee?> GetEmployeeWithAssetsAsync(Guid employeeId);

    // Task<bool> ExistsAsync(Guid employeeId);
}