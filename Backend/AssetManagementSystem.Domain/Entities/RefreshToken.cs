using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Domain.Entities;

public class RefreshToken
{
    [Key]
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiryDate { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime CreatedAt { get; set; }

    public Employee Employee { get; set; } = null!;
}