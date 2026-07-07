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

    
}