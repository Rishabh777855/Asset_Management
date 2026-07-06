namespace AssetManagementSystem.Application.DTOs.Employee;

public class CreateEmployeeDto
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string Department { get; set; }

    public required string Designation { get; set; }
}