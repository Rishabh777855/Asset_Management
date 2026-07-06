namespace AssetManagementSystem.Application.DTOs.Asset;

public class UpdateAssetDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Brand { get; set; }

    public required string Model { get; set; }

    public required string SerialNumber { get; set; }

   // public Guid AssetCategoryId { get; set; } // available only to admin for unecessary changes and be implement using RBAC

    public string? Remarks { get; set; }
}