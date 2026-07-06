using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.DTOs.Asset;

public class AssetResponseDto
{
    public Guid Id { get; set; }

    public string AssetCode { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public AssetStatus Status { get; set; }

    public DateTime PurchaseDate { get; set; }

    public decimal PurchasePrice { get; set; }

    public DateTime WarrantyExpiryDate { get; set; }

    public string? Remarks { get; set; }
}