using AssetManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetCategoryController(IAssetCategoryService assetCategoryService)
    : ControllerBase
{
    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await assetCategoryService.GetAllAssetCategoriesAsync();

        return Ok(categories);
    }
}