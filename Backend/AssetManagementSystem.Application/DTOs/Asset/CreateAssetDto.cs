namespace AssetManagementSystem.Application.DTOs.Asset;

public class CreateAssetDto
{
    public required string AssetCode { get; set; }

    public required string Name { get; set; }

    public required string Brand { get; set; }

    public required string Model { get; set; }

    public required string SerialNumber { get; set; }

    public Guid AssetCategoryId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public decimal PurchasePrice { get; set; }

    public DateOnly WarrantyExpiryDate { get; set; }

    public string? Remarks { get; set; }
}