using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.DTOs.Common;

namespace AssetManagementSystem.Application.Interfaces;

public interface IAssetAssignmentService
{
    Task AssignAssetAsync(AssignAssetDto dto, CancellationToken cancellationToken);

    Task ReturnAssetAsync(ReturnAssetDto dto, CancellationToken cancellationToken);

    Task<IEnumerable<AssetAssignmentResponseDto>> GetEmployeeAssetsAsync(Guid employeeId, CancellationToken cancellationToken);

    Task<AssetAssignmentResponseDto?> GetCurrentAssignmentAsync(Guid assetId, CancellationToken cancellationToken);

    Task<PagedResponse<AssetAssignmentResponseDto?>> GetAllActiveAssignmentsAsync(AssetAssignmentFilterDto assetAssignmentFilterDto, CancellationToken cancellationToken);
}