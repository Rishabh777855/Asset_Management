using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.DTOs.Common;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Interfaces;

public interface IFilterService
{
    IQueryable<AssetAssignment> ApplyFiltersForAssetAssignment(IQueryable<AssetAssignment> query, AssetAssignmentFilterDto assetAssignmentFilterDto);

    IQueryable<Asset> ApplyFiltersForAsset(IQueryable<Asset> query, AssetFilterDto assetFilterDto);

    IQueryable<T> ApplyPagination<T>(IQueryable<T> query, QueryFilter filter);

}