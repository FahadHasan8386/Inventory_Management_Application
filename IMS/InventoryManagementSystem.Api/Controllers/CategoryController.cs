using InventoryManagementSystem.Api.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            return Ok(await _categoryService.GetCategoryAsync());
        }

        [HttpGet("GetCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(long categoryId)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(categoryId));
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync(long categoryId)
        {
            if (categoryId == 0)
                return BadRequest();

            return Ok(await _categoryService.DeleteCategoryAsync(categoryId));
        }
    }
}
