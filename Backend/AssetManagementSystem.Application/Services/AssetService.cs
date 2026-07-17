using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Application.Services;

public class AssetService(IAssetRepository assetRepository, IRepository<AssetCategory> categoryRepository, IUnitOfWork unitOfWork, IFilterService filterService) : IAssetService
{
    public async Task<IEnumerable<AssetResponseDto>> GetAllAssetsWithCategoryAsync(AssetFilterDto assetFilterDto, CancellationToken cancellationToken)
    {
        var query = assetRepository.GetAllAssetsWithCategoryAsync();

        query = filterService.ApplyFiltersForAsset(query, assetFilterDto);

        var assets = await query.ToListAsync(cancellationToken);

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<AssetResponseDto?> GetAssetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetAssetWithCategoryAsync(id, cancellationToken);

        if (asset == null)
            return null;

        return AssetMapper.ToResponseDto(asset);
    }

    public async Task<IEnumerable<AssetResponseDto>> GetAvailableAssetsAsync(CancellationToken cancellationToken)
    {
        var assets = await assetRepository.GetAvailableAssetsAsync(cancellationToken);

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<IEnumerable<AssetResponseDto>> GetAssetsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var assets = await assetRepository.GetAssetsByCategoryAsync(categoryId, cancellationToken);

        return assets.Select(AssetMapper.ToResponseDto);
    }

    public async Task<AssetResponseDto> CreateAssetAsync(CreateAssetDto dto, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(dto.AssetCategoryId, cancellationToken);

        if (category == null)
            throw new NotFoundException("Asset category not found.");

        var asset = AssetMapper.ToEntity(dto);

        await assetRepository.AddAsync(asset, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        asset.AssetCategory = category;

        return AssetMapper.ToResponseDto(asset);
    }

    public async Task<AssetResponseDto> UpdateAssetAsync(Guid id, UpdateAssetDto dto, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetByIdAsync(id, cancellationToken);

        if (asset == null)
            throw new NotFoundException("Asset not found.");

        AssetMapper.UpdateEntity(dto, asset);

        await assetRepository.UpdateAsync(asset, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        asset = await assetRepository.GetAssetWithCategoryAsync(asset.Id, cancellationToken);

        return AssetMapper.ToResponseDto(asset!);
    }

    public async Task DeleteAssetAsync(Guid id, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetByIdAsync(id, cancellationToken);

        if (asset == null)
            throw new NotFoundException("Asset not found.");

        if(asset.Status != AssetStatus.Available && asset.Status != AssetStatus.Retired )
            throw new BadRequestException("Only Available or Retired Assets can be Deleted");

        asset.IsActive = false;

        await assetRepository.UpdateAsync(asset, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}