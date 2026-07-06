using AssetManagementSystem.Application.DTOs.Employee;

namespace AssetManagementSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync();

    Task<EmployeeResponseDto?> GetEmployeeByIdAsync(Guid id);

    Task CreateEmployeeAsync(CreateEmployeeDto dto);

    Task UpdateEmployeeAsync(UpdateEmployeeDto dto);

    Task DeleteEmployeeAsync(Guid id);
}