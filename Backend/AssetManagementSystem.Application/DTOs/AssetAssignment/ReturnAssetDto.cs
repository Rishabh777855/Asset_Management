namespace AssetManagementSystem.Application.DTOs.AssetAssignment;

public class ReturnAssetDto
{
    public Guid AssetId { get; set; }

    public DateTime ReturnDate { get; set; }

    public string? Remarks { get; set; }
}