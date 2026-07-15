using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Helper;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync(CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetAllAsync(cancellationToken);

        return employees.Select(EmployeeMapper.ToResponseDto);
    }

    public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(id, cancellationToken);

        if (employee == null)
            return null;

        return EmployeeMapper.ToResponseDto(employee);
    }

    public async Task CreateEmployeeAsync(CreateEmployeeDto dto, CancellationToken cancellationToken)
    {
        if (await employeeRepository.GetByEmailAsync(dto.Email, cancellationToken) != null)
            throw new UnauthorizedException("Email already exists.");

        var employee = EmployeeMapper.ToEntity(dto);

        employee.PasswordHash = PasswordHash.HashPassword(dto.Password);

        await employeeRepository.AddAsync(employee, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(id, cancellationToken);

        if (employee == null)
            throw new NotFoundException("Employee not found.");

        EmployeeMapper.UpdateEntity(dto, employee);

        await employeeRepository.UpdateAsync(employee, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(id, cancellationToken);

        if (employee == null)
            throw new NotFoundException("Employee not found.");

        employee.IsActive = false;

        await employeeRepository.UpdateAsync(employee, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}