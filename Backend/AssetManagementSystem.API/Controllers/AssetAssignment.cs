using AssetManagementSystem.Application.DTOs.AssetAssignment;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[ApiController]
[Route("api/[controller]")]

public class AssetAssignmentController(IAssetAssignmentService assetAssignmentService) : ControllerBase
{
    [HttpPost("assign")]
    public async Task<IActionResult> AssignAssets(AssignAssetDto assignAssetDto)
    {
        await assetAssignmentService.AssignAssetAsync(assignAssetDto);

        return Ok("Asset assigned successfully");
    }

    [HttpPost("return")]
    public async Task<IActionResult> ReturnAssets(ReturnAssetDto returnAssetDto)
    {
        await assetAssignmentService.ReturnAssetAsync(returnAssetDto);

        return Ok("Asset returned successfully");
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeAsset(Guid employeeId)
    {
        var asset = await assetAssignmentService.GetEmployeeAssetsAsync(employeeId);

        return Ok(asset);
    }

     [HttpGet("current/{assetId:guid}")]
    public async Task<IActionResult> GetCurrentAssignment(Guid assetId)
    {
        var assignment = await assetAssignmentService.GetCurrentAssignmentAsync(assetId);

        if (assignment == null)
            return NotFound();

        return Ok(assignment);
    }
}