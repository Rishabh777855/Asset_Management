using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Domain.Entities;

public class Employee
{
    [Key]
    public Guid Id { get; set; }

    // public string EmployeeCode { get; set; } = string.Empty;

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public required string Department { get; set; }

    public required string Designation { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}