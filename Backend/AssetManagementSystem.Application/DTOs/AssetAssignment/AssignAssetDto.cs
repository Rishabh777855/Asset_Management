namespace AssetManagementSystem.Application.DTOs.AssetAssignment;

public class AssignAssetDto
{
    public Guid AssetId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime AssignedDate { get; set; }

    public string? Remarks { get; set; }
}