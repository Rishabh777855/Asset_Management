using AssetManagementSystem.Application.DTOs;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.Mapper;

public static class AssetHistoryMapper
{
    public static AssetHistoryResponseDto ToResponseDto(AssetHistory history)
    {
        return new AssetHistoryResponseDto
        {
            Id = history.Id,
            AssetCode = history.Asset.AssetCode,
            AssetName = history.Asset.Name,
            HistoryType = history.HistoryType.ToString(),
            EmployeeName = history.Employee != null
                ? $"{history.Employee.FirstName} {history.Employee.LastName}"
                : string.Empty,
            ActionDate = history.ActionDate,
            Remarks = history.Remarks
        };
    }
    public static AssetHistory ToEntity(
        Guid assetId,
        Guid? employeeId,
        AssetHistoryType historyType,
        string? remarks)
    {
        return new AssetHistory
        {
            AssetId = assetId,
            EmployeeId = employeeId,
            HistoryType = historyType,
            ActionDate = DateTime.UtcNow,
            Remarks = remarks
        };
    }
}
