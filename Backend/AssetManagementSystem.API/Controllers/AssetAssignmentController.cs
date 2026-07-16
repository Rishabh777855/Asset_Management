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
    public async Task<IActionResult> AssignAssetsAsync(AssignAssetDto assignAssetDto, CancellationToken cancellationToken)
    {
        await assetAssignmentService.AssignAssetAsync(assignAssetDto, cancellationToken);

        return Ok("Asset assigned successfully");
    }

    [HttpPost("return")]
    public async Task<IActionResult> ReturnAssetsAsync(ReturnAssetDto returnAssetDto, CancellationToken cancellationToken)
    {
        await assetAssignmentService.ReturnAssetAsync(returnAssetDto, cancellationToken);

        return Ok("Asset returned successfully");
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeAssetsAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        var result = await assetAssignmentService.GetEmployeeAssetsAsync(employeeId, cancellationToken);

        return Ok(result);
    }

     [HttpGet("current/{assetId:guid}")]
    public async Task<IActionResult> GetCurrentAssignmentAsync(Guid assetId, CancellationToken cancellationToken)
    {
        var result = await assetAssignmentService.GetCurrentAssignmentAsync(assetId, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [Authorize]
    [HttpGet("activeAssignments")]
    public async Task<IActionResult> GetAllActiveAssignments(CancellationToken cancellationToken)
    {
        var result = await assetAssignmentService.GetAllActiveAssignmentsAsync(cancellationToken);

        return Ok(result);
    }
}