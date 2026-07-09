using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.Exceptions;
using AssetManagementSystem.Application.Interfaces;
using AssetManagementSystem.Application.Mappers;
using AssetManagementSystem.Domain.Entities;
using AssetManagementSystem.Domain.Enums;
using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Application.Services;

public class AssetAssignmentService(IAssetRepository assetRepository, IEmployeeRepository employeeRepository, IAssetAssignmentRepository assignmentRepository, IUnitOfWork unitOfWork) : IAssetAssignmentService
{
    public async Task AssignAssetAsync(AssignAssetDto dto)
    {
        var employeeExists = await employeeRepository.ExistsAsync(dto.EmployeeId);

        if (!employeeExists)
            throw new NotFoundException("Employee not found.");

        var asset = await assetRepository.GetByIdAsync(dto.AssetId);

        if (asset == null)
            throw new Exception("Asset not found.");

        if (asset.Status != AssetStatus.Available)
            throw new NotFoundException("Asset is not available.");

        if (!asset.IsActive)
            throw new BadRequestException("Asset is not available or inactive");

        var assignment = AssetAssignmentMapper.ToEntity(dto);

        asset.Status = AssetStatus.Assigned;

        await assetRepository.UpdateAsync(asset);

        await assignmentRepository.AddAsync(assignment);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task ReturnAssetAsync(ReturnAssetDto dto)
    {
        var assignment = await assignmentRepository.GetActiveAssignmentAsync(dto.AssetId);

        if (assignment == null)
            throw new NotFoundException("No active assignment found.");

        assignment.ReturnDate = dto.ReturnDate;
        assignment.Status = AssignmentStatus.Returned;
        assignment.Remarks = dto.Remarks;

        assignment.Asset.Status = AssetStatus.Available;

        await assignmentRepository.UpdateAsync(assignment);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<AssetAssignmentResponseDto>> GetEmployeeAssetsAsync(Guid employeeId)
    {
        var assignments = await assignmentRepository.GetEmployeeAssignmentsAsync(employeeId);

        return assignments.Select(AssetAssignmentMapper.ToResponseDto);
    }

    public async Task<AssetAssignmentResponseDto?> GetCurrentAssignmentAsync(Guid assetId)
    {
        var assignment = await assignmentRepository.GetActiveAssignmentAsync(assetId);

        if (assignment == null)
            return null;

        return AssetAssignmentMapper.ToResponseDto(assignment);
    }
}