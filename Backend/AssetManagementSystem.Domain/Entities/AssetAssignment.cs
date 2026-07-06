using System.ComponentModel.DataAnnotations;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Domain.Entities;

public class AssetAssignment
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid AssetId { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public DateOnly AssignedDate { get; set; }
    
    public DateOnly? ReturnDate { get; set; }
    
    public AssignmentStatus Status { get; set; }
    
    public string? Remarks { get; set; }
    
    public Employee Employee { get; set; } = null!;
    
    public Asset Asset { get; set; } = null!;
}