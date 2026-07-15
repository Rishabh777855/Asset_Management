using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetController(IAssetService assetService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var assets = await assetService.GetAllAssetsWithCategoryAsync(cancellationToken);

        return Ok(assets);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAssetById(Guid id, CancellationToken cancellationToken)
    {
        var asset = await assetService.GetAssetByIdAsync(id, cancellationToken);

        if (asset == null)
            return NotFound();

        return Ok(asset);
    }

    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetAssetByCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        var asset = await assetService.GetAssetsByCategoryAsync(categoryId, cancellationToken);

        return Ok(asset);
    }

    [HttpGet("available-assets")]
    public async Task<IActionResult> GetAvailableAssets(CancellationToken cancellationToken)
    {
        var asset = await assetService.GetAvailableAssetsAsync(cancellationToken);

        return Ok(asset);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsset(CreateAssetDto createAssetDto, CancellationToken cancellationToken)
    {
        var asset = await assetService.CreateAssetAsync(createAssetDto, cancellationToken);

        return Ok(asset);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsset(Guid id, UpdateAssetDto updateAssetDto, CancellationToken cancellationToken)
    {
        var asset = await assetService.UpdateAssetAsync(id, updateAssetDto, cancellationToken);

        return Ok(asset);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsset(Guid id, CancellationToken cancellationToken)
    {
        await assetService.DeleteAssetAsync(id, cancellationToken);

        return NoContent();
    }
}