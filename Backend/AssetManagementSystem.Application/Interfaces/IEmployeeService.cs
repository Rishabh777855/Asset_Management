using AssetManagementSystem.Application.DTOs.Employee;

namespace AssetManagementSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync(CancellationToken cancellationToken);

    Task<EmployeeResponseDto?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken);

    Task CreateEmployeeAsync(CreateEmployeeDto dto, CancellationToken cancellationToken);

    Task UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto, CancellationToken cancellationToken);

    Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}