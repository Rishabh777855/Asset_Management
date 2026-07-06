using AssetManagementSystem.Application.DTOs.AssetAssignment;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetAssignmentService
{
    Task AssignAssetAsync(AssignAssetDto dto);

    Task ReturnAssetAsync(ReturnAssetDto dto);

    Task<IEnumerable<AssetAssignmentResponseDto>> GetEmployeeAssetsAsync(Guid employeeId);

    Task<AssetAssignmentResponseDto?> GetCurrentAssignmentAsync(Guid assetId);
}