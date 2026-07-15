using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mapper;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AssetCategoryService(IRepository<AssetCategory> categoryRepository)
    : IAssetCategoryService
{
    public async Task<IEnumerable<AssetCategoryResponseDto>> GetAllAssetCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync(cancellationToken);

        return categories.Select(AssetCategoryMapper.ToResponseDto);
    }
}