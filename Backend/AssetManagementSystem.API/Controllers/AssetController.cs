using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetController(IAssetService assetService, IAssetHistoryService assetHistoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAssetsAsync([FromQuery] AssetFilterDto assetFilterDto, CancellationToken cancellationToken)
    {
        var result = await assetService.GetAllAssetsWithCategoryAsync(assetFilterDto, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAssetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await assetService.GetAssetByIdAsync(id, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAssetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var result = await assetService.GetAssetsByCategoryAsync(categoryId, cancellationToken);

        return Ok(result);
    }

    [HttpGet("available-assets")]
    public async Task<IActionResult> GetAvailableAssetsAsync(CancellationToken cancellationToken)
    {
        var result = await assetService.GetAvailableAssetsAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssetAsync(CreateAssetDto createAssetDto, CancellationToken cancellationToken)
    {
        var result = await assetService.CreateAssetAsync(createAssetDto, cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAssetAsync(Guid id, UpdateAssetDto updateAssetDto, CancellationToken cancellationToken)
    {
        var result = await assetService.UpdateAssetAsync(id, updateAssetDto, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAssetAsync(Guid id, CancellationToken cancellationToken)
    {
        await assetService.DeleteAssetAsync(id, cancellationToken);

        return NoContent();
    }

    [HttpGet("{id:guid}/history")]
    public async Task<IActionResult> GetAssetHistoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await assetHistoryService.GetAssetHistoryAsync(id, cancellationToken);

        return Ok(result);
    }
}