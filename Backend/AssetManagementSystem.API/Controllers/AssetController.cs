using AssetManagementSystem.Application.DTOs.Asset;
using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controller;


[ApiController]
[Route("api/controller")]
public class AssetController(IAssetService assetService) : ControllerBase
{
    [HttpGet]
    public async Task <IActionResult> GetAll()
    {
        var assets = await assetService.GetAllAssetsAsync();

        return Ok(assets);
    }

    [HttpGet("{id:guid}")]
    public async Task <IActionResult> GetAssetById(Guid id)
    {
        var asset = await assetService.GetAssetByIdAsync(id);

        if(asset == null)
          return NotFound();

        return Ok(asset);
    }

    [HttpGet("category/{categoryId:guid}")]
    public async Task <IActionResult> GetAssetByCategory(Guid categoryId)
    {
       var asset = await assetService.GetAssetsByCategoryAsync(categoryId);

       return Ok(asset);
    }


    [HttpPost]
    public async Task <IActionResult> CreateAsset(CreateAssetDto createAssetDto)
    {
        var asset = await assetService.CreateAssetAsync(createAssetDto);

        return Ok(asset);
    }
}