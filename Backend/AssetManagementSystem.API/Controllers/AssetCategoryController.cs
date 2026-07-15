using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetCategoryController(IAssetCategoryService assetCategoryService, CancellationToken cancellationToken)
    : ControllerBase
{
    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await assetCategoryService.GetAllAssetCategoriesAsync(cancellationToken);

        return Ok(categories);
    }
}