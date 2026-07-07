using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AssetService(IAssetRepository assetRepository, IRepository<AssetCategory> categoryRepository, IUnitOfWork unitOfWork) : IAssetService
{
    public async Task<IEnumerable<AssetResponseDto>> GetAllAssetsWithCategoryAsync()
    {
        var assets = await assetRepository.GetAllAssetsWithCategoryAsync();

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<AssetResponseDto?> GetAssetByIdAsync(Guid id)
    {
        var asset = await assetRepository.GetAssetWithCategoryAsync(id);

        if (asset == null)
            return null;

        return AssetMapper.ToResponseDto(asset);
    }

    public async Task<IEnumerable<AssetResponseDto>> GetAvailableAssetsAsync()
    {
        var assets = await assetRepository.GetAvailableAssetsAsync();

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<IEnumerable<AssetResponseDto>> GetAssetsByCategoryAsync(Guid categoryId)
    {
        var assets = await assetRepository.GetAssetsByCategoryAsync(categoryId);

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<AssetResponseDto> CreateAssetAsync(CreateAssetDto dto)
    {
        var category = await categoryRepository.GetByIdAsync(dto.AssetCategoryId);

        if (category == null)
            throw new Exception("Asset category not found.");

        var asset = AssetMapper.ToEntity(dto);

        await assetRepository.AddAsync(asset);

        await unitOfWork.SaveChangesAsync();

        asset.AssetCategory = category;

        return AssetMapper.ToResponseDto(asset);
    }

    public async Task<AssetResponseDto> UpdateAssetAsync(Guid id, UpdateAssetDto dto)
    {
        var asset = await assetRepository.GetByIdAsync(id);

        if (asset == null)
            throw new Exception("Asset not found.");

        AssetMapper.UpdateEntity(dto, asset);

        await assetRepository.UpdateAsync(asset);

        await unitOfWork.SaveChangesAsync();

        asset = await assetRepository.GetAssetWithCategoryAsync(asset.Id);

        return AssetMapper.ToResponseDto(asset!);
    }

    public async Task DeleteAssetAsync(Guid id)
    {
        var asset = await assetRepository.GetByIdAsync(id);

        if (asset == null)
            throw new Exception("Asset not found.");

        await assetRepository.DeleteAsync(id);

        await unitOfWork.SaveChangesAsync();
    }
}