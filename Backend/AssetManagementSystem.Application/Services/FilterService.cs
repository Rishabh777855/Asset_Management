using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.DTOs.Common;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Services;

public class FilterService : IFilterService
{
    public IQueryable<AssetAssignment> ApplyFiltersForAssetAssignment(IQueryable<AssetAssignment> query, AssetAssignmentFilterDto assetAssignmentFilterDto)
    {
        if (!string.IsNullOrWhiteSpace(assetAssignmentFilterDto.Search))
        {
            var search = assetAssignmentFilterDto.Search.Trim();

            query = query.Where(a =>
                a.Employee.FirstName.Contains(search) ||
                a.Employee.LastName.Contains(search) ||
                a.Asset.AssetCode.Contains(search) ||
                a.Asset.Name.Contains(search) ||
                a.Asset.AssetCategory.Name.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(assetAssignmentFilterDto.EmployeeName))
        {
            query = query.Where(a =>
                (a.Employee.FirstName + " " + a.Employee.LastName)
                .Contains(assetAssignmentFilterDto.EmployeeName));
        }

        if (!string.IsNullOrWhiteSpace(assetAssignmentFilterDto.AssetCode))
        {
            query = query.Where(a =>
                a.Asset.AssetCode.Contains(assetAssignmentFilterDto.AssetCode));
        }

        if (!string.IsNullOrWhiteSpace(assetAssignmentFilterDto.AssetName))
        {
            query = query.Where(a =>
                a.Asset.Name.Contains(assetAssignmentFilterDto.AssetName));
        }

        if (assetAssignmentFilterDto.Status.HasValue)
        {
            query = query.Where(a =>
                a.Status == assetAssignmentFilterDto.Status.Value);
        }

        if (assetAssignmentFilterDto.AssignedDate.HasValue)
        {
            query = query.Where(a =>
                a.AssignedDate == assetAssignmentFilterDto.AssignedDate.Value);
        }

        return query;
    }

    public IQueryable<Asset> ApplyFiltersForAsset(IQueryable<Asset> query, AssetFilterDto assetFilterDto)
    {
        if (!string.IsNullOrWhiteSpace(assetFilterDto.Search))
        {
            var search = assetFilterDto.Search.Trim();

            query = query.Where(a =>
                a.AssetCode.Contains(search) ||
                a.Name.Contains(search) ||
                a.Brand.Contains(search) ||
                a.Model.Contains(search) ||
                a.AssetCategory.Name.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(assetFilterDto.AssetCode))
        {
            query = query.Where(a =>
                a.AssetCode.Contains(assetFilterDto.AssetCode));
        }

        if (!string.IsNullOrWhiteSpace(assetFilterDto.AssetName))
        {
            query = query.Where(a =>
                a.Name.Contains(assetFilterDto.AssetName));
        }

        if (!string.IsNullOrWhiteSpace(assetFilterDto.Brand))
        {
            query = query.Where(a =>
                a.Brand.Contains(assetFilterDto.Brand));
        }

        if (!string.IsNullOrWhiteSpace(assetFilterDto.Model))
        {
            query = query.Where(a =>
                a.Model.Contains(assetFilterDto.Model));
        }

        if (!string.IsNullOrWhiteSpace(assetFilterDto.CategoryName))
        {
            query = query.Where(a =>
                a.AssetCategory.Name.Contains(assetFilterDto.CategoryName));
        }

        return query;
    }

    public IQueryable<T> ApplyPagination<T>(IQueryable<T> query, QueryFilter filter)
    {
        return query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize);
    }
}