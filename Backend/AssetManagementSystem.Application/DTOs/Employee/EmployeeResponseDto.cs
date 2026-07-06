namespace AssetManagementSystem.Application.DTOs.Employee;

public class EmployeeResponseDto
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Department { get; set; }

    public required string Designation { get; set; }

   // public bool IsActive { get; set; }  can be visible to admin only and not to employee will be done when implementing RBAC

    public DateTime CreatedAt { get; set; }
}