using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Domain.Entities;

public class AssetCategory
{
    [Key]
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}