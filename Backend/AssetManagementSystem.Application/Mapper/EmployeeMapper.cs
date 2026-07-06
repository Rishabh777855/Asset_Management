using AssetManagementSystem.Application.DTOs.Employee;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Mappers;

public static class EmployeeMapper
{
    public static Employee ToEntity(CreateEmployeeDto dto)
    {
        return new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Department = dto.Department,
            Designation = dto.Designation,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(UpdateEmployeeDto dto, Employee employee)
    {
        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Department = dto.Department;
        employee.Designation = dto.Designation;
    }

    public static EmployeeResponseDto ToResponseDto(Employee employee)
    {
        return new EmployeeResponseDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            Designation = employee.Designation
        };
    }
}