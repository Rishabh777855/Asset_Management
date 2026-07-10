using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Mapper;

public static class AssetCategoryMapper
{

    public static AssetCategoryResponseDto ToResponseDto(AssetCategory category)
    {
        return new AssetCategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}