using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork)
    : IEmployeeService
{
    public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllAsync();

        return employees.Select(EmployeeMapper.ToResponseDto);
    }

    public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return null;

        return EmployeeMapper.ToResponseDto(employee);
    }

    public async Task CreateEmployeeAsync(CreateEmployeeDto dto)
    {
        if (await employeeRepository.GetByEmailAsync(dto.Email) != null)
            throw new Exception("Email already exists.");

        var employee = EmployeeMapper.ToEntity(dto);

        // Later
        // employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await employeeRepository.AddAsync(employee);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeDto dto)
    {
        var employee = await employeeRepository.GetByIdAsync(dto.Id);

        if (employee == null)
            throw new Exception("Employee not found.");

        EmployeeMapper.UpdateEntity(dto, employee);

        await employeeRepository.UpdateAsync(employee);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);

        if (employee == null)
            throw new Exception("Employee not found.");

        await employeeRepository.DeleteAsync(id);

        await unitOfWork.SaveChangesAsync();
    }
}