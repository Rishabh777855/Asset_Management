using AssetManagementSystem.Application.DTOs.AssetAssignment;
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
}