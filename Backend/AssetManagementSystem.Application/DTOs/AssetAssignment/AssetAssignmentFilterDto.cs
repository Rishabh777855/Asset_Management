using AssetManagementSystem.Application.DTOs.Common;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.DTOs.AssetAssignment;

public class AssetAssignmentFilterDto : QueryFilter
{
    public string? EmployeeName { get; set; }

    public string? AssetCode { get; set; }

    public string? AssetName { get; set; }

    public AssignmentStatus? Status { get; set; }

    public DateOnly? AssignedDate { get; set; }
}