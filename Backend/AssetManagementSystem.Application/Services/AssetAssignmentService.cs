using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mapper;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AssetAssignmentService(IAssetRepository assetRepository, IEmployeeRepository employeeRepository, IAssetAssignmentRepository assignmentRepository, IAssetHistoryRepository assetHistoryRepository, IUnitOfWork unitOfWork) : IAssetAssignmentService
{
    public async Task AssignAssetAsync(AssignAssetDto assignAssetDto, CancellationToken cancellationToken)
    {
        var employeeExists = await employeeRepository.ExistsAsync(assignAssetDto.EmployeeId, cancellationToken);

        if (!employeeExists)
            throw new NotFoundException("Employee not found.");

        var asset = await assetRepository.GetByIdAsync(assignAssetDto.AssetId, cancellationToken);

        if (asset == null)
            throw new Exception("Asset not found.");

        if (asset.Status != AssetStatus.Available)
            throw new NotFoundException("Asset is not available.");

        if (!asset.IsActive)
            throw new BadRequestException("Asset is not available or inactive");

        var assignment = AssetAssignmentMapper.ToEntity(assignAssetDto);

        var history = AssetHistoryMapper.ToEntity(asset.Id, assignAssetDto.EmployeeId, AssetHistoryType.Assigned, assignAssetDto.Remarks);

        asset.Status = AssetStatus.Assigned;

        await assetRepository.UpdateAsync(asset, cancellationToken);

        await assignmentRepository.AddAsync(assignment, cancellationToken);

        await assetHistoryRepository.AddAsync(history, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task ReturnAssetAsync(ReturnAssetDto returnAssetDto, CancellationToken cancellationToken)
    {
        var assignment = await assignmentRepository.GetActiveAssignmentAsync(returnAssetDto.AssetId, cancellationToken);

        if (assignment == null)
            throw new NotFoundException("No active assignment found.");

        assignment.ReturnDate = returnAssetDto.ReturnDate;
        assignment.Status = AssignmentStatus.Returned;
        assignment.Remarks = returnAssetDto.Remarks;

        assignment.Asset.Status = AssetStatus.Available;

        var history = AssetHistoryMapper.ToEntity(assignment.AssetId, assignment.EmployeeId, AssetHistoryType.Returned, returnAssetDto.Remarks);

        await assetHistoryRepository.AddAsync(history, cancellationToken);

        await assignmentRepository.UpdateAsync(assignment, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<AssetAssignmentResponseDto>> GetEmployeeAssetsAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        var assignments = await assignmentRepository.GetEmployeeAssignmentsAsync(employeeId, cancellationToken);

        return assignments.Select(AssetAssignmentMapper.ToResponseDto);
    }

    public async Task<AssetAssignmentResponseDto?> GetCurrentAssignmentAsync(Guid assetId, CancellationToken cancellationToken)
    {
        var assignment = await assignmentRepository.GetActiveAssignmentAsync(assetId, cancellationToken);

        if (assignment == null)
            return null;

        return AssetAssignmentMapper.ToResponseDto(assignment);
    }
}