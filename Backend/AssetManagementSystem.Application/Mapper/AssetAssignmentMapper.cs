using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;

namespace AssetManagementSystem.Application.Mappers;

public static class AssetAssignmentMapper
{
    public static AssetAssignment ToEntity(AssignAssetDto dto)
    {
        return new AssetAssignment
        {
            AssetId = dto.AssetId,
            EmployeeId = dto.EmployeeId,
            AssignedDate = dto.AssignedDate,
            Remarks = dto.Remarks,
            Status = AssignmentStatus.Active
        };
    }

    public static AssetAssignmentResponseDto ToResponseDto(AssetAssignment assignment)
    {
        return new AssetAssignmentResponseDto
        {
            Id = assignment.Id,
            EmployeeName = $"{assignment.Employee.FirstName} {assignment.Employee.LastName}",
            AssetCode = assignment.Asset.AssetCode,
            AssetName = assignment.Asset.Name,
            AssignedDate = assignment.AssignedDate,
            ReturnDate = assignment.ReturnDate,
            Status = assignment.Status,
           // CategoryName = asset.AssetCategory.Name,
            Remarks = assignment.Remarks
        };
    }
}