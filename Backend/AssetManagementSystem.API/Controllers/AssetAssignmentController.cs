using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class AssetAssignmentController(IAssetAssignmentService assetAssignmentService) : ControllerBase
{
    [HttpPost("assign")]
    public async Task<IActionResult> AssignAssets(AssignAssetDto assignAssetDto, CancellationToken cancellationToken)
    {
        await assetAssignmentService.AssignAssetAsync(assignAssetDto, cancellationToken);

        return Ok("Asset assigned successfully");
    }

    [HttpPost("return")]
    public async Task<IActionResult> ReturnAssets(ReturnAssetDto returnAssetDto, CancellationToken cancellationToken)
    {
        await assetAssignmentService.ReturnAssetAsync(returnAssetDto, cancellationToken);

        return Ok("Asset returned successfully");
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeAsset(Guid employeeId, CancellationToken cancellationToken)
    {
        var asset = await assetAssignmentService.GetEmployeeAssetsAsync(employeeId, cancellationToken);

        return Ok(asset);
    }

     [HttpGet("current/{assetId:guid}")]
    public async Task<IActionResult> GetCurrentAssignment(Guid assetId, CancellationToken cancellationToken)
    {
        var assignment = await assetAssignmentService.GetCurrentAssignmentAsync(assetId, cancellationToken);

        if (assignment == null)
            return NotFound();

        return Ok(assignment);
    }
}