using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.Mappers;

public static class AssetMapper
{
    public static Asset ToEntity(CreateAssetDto dto)
    {
        return new Asset
        {
            AssetCode = dto.AssetCode,
            Name = dto.Name,
            Brand = dto.Brand,
            Model = dto.Model,
            SerialNumber = dto.SerialNumber,
            AssetCategoryId = dto.AssetCategoryId,
            PurchaseDate = dto.PurchaseDate,
            PurchasePrice = dto.PurchasePrice,
            WarrantyExpiryDate = dto.WarrantyExpiryDate,
            Remarks = dto.Remarks,
            Status = AssetStatus.Available
        };
    }

    public static void UpdateEntity(UpdateAssetDto dto, Asset asset)
    {
        asset.Name = dto.Name;
        asset.Brand = dto.Brand;
        asset.Model = dto.Model;
        asset.SerialNumber = dto.SerialNumber;
        asset.Remarks = dto.Remarks;
    }

    public static AssetResponseDto ToResponseDto(Asset asset)
    {
        return new AssetResponseDto
        {
            Id = asset.Id,
            AssetCode = asset.AssetCode,
            Name = asset.Name,
            Brand = asset.Brand,
            Model = asset.Model,
            SerialNumber = asset.SerialNumber,
            CategoryName = asset.AssetCategory.Name,
            PurchaseDate = asset.PurchaseDate,
            PurchasePrice = asset.PurchasePrice,
            WarrantyExpiryDate = asset.WarrantyExpiryDate,
            Status = asset.Status.ToString(),
            Remarks = asset.Remarks
        };
    }
}