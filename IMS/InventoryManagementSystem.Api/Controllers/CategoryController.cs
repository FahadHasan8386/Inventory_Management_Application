using IMS.Shared.Models.DtoModel;
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

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest();
            }
            return Ok(await _categoryService.AddCategoryAsync(categoryDto));
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest();
            }
            return Ok(await _categoryService.UpdateCategoryAsync(categoryDto));
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
