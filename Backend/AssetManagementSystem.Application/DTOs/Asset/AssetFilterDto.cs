using AssetManagementSystem.Application.DTOs.Common;

namespace AssetManagementSystem.Application.DTOs.Asset;

public class AssetFilterDto : QueryFilter
{
    public string? AssetCode { get; set; }

    public string? AssetName { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? CategoryName { get; set; }
}