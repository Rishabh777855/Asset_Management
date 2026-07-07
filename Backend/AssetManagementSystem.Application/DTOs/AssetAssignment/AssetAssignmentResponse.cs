using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.DTOs.AssetAssignment;

public class AssetAssignmentResponseDto
{
    public Guid Id { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public string AssetCode { get; set; } = string.Empty;

    public string AssetName { get; set; } = string.Empty;

    public DateOnly AssignedDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public AssignmentStatus Status { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string? Remarks { get; set; }
}