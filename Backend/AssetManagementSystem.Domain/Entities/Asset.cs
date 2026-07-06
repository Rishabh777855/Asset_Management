using System.ComponentModel.DataAnnotations;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Domain.Entities;

public class Asset
{
    [Key]
    public Guid Id { get; set; }

    public Guid AssetCategoryId { get; set; }

    public required string AssetCode { get; set; }

    public required string Name { get; set; } 

    public required string Brand { get; set; } 

    public required string Model { get; set; } 

    public required string SerialNumber { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public decimal PurchasePrice { get; set; }

    public DateOnly WarrantyExpiryDate { get; set; }

    public AssetStatus Status { get; set; }

    public string? Remarks { get; set; }

    public AssetCategory AssetCategory { get; set; } = null!;

    public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();

   // public ICollection<AssetHistory> AssetHistories { get; set; } = new List<AssetHistory>();
}