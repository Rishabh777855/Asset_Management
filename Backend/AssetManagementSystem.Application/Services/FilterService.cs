using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Domain.Entities;

namespace AssetManagementSystem.Application.Services;

public class AssetAssignmentFilterService : IFilterService
{
    public IQueryable<AssetAssignment> ApplyFiltersForAssetAssignment(IQueryable<AssetAssignment> query, AssetAssignmentFilterDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var search = filter.Search.Trim();

            query = query.Where(a =>
                a.Employee.FirstName.Contains(search) ||
                a.Employee.LastName.Contains(search) ||
                a.Asset.AssetCode.Contains(search) ||
                a.Asset.Name.Contains(search) ||
                a.Asset.AssetCategory.Name.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(filter.EmployeeName))
        {
            query = query.Where(a =>
                (a.Employee.FirstName + " " + a.Employee.LastName)
                .Contains(filter.EmployeeName));
        }

        if (!string.IsNullOrWhiteSpace(filter.AssetCode))
        {
            query = query.Where(a =>
                a.Asset.AssetCode.Contains(filter.AssetCode));
        }

        if (!string.IsNullOrWhiteSpace(filter.AssetName))
        {
            query = query.Where(a =>
                a.Asset.Name.Contains(filter.AssetName));
        }

        if (filter.Status.HasValue)
        {
            query = query.Where(a =>
                a.Status == filter.Status.Value);
        }

        if (filter.AssignedDate.HasValue)
        {
            query = query.Where(a =>
                a.AssignedDate == filter.AssignedDate.Value);
        }

        return query;
    }
}