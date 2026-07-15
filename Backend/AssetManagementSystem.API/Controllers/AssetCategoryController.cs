using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetCategoryController(IAssetCategoryService assetCategoryService)
    : ControllerBase
{
    [HttpGet("categories")]
    public async Task<IActionResult> GetAllAssetCategoriesAsync(CancellationToken cancellationToken)
    {
        var result = await assetCategoryService.GetAllAssetCategoriesAsync(cancellationToken);

        return Ok(result);
    }
}