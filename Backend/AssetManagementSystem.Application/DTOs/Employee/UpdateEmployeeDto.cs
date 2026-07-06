namespace AssetManagementSystem.Application.DTOs.Employee;

public class UpdateEmployeeDto
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Department { get; set; }

    public required string Designation { get; set; }
}