using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            return Ok(await _productService.GetProductAsync());
        }

        [HttpGet("GetProductById/{productId}")]
        public async Task<IActionResult> GetProductByIdAsync(long productId)
        {
            return Ok(await _productService.GetProductByIdAsync(productId));
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }
            return Ok(await _productService.AddProductAsync(productDto));
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }
            return Ok(await _productService.UpdateProductAsync(productDto));
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProductAsync(long productId)
        {
            if (productId == 0)
                return BadRequest();

            return Ok(await _productService.DeleteProductAsync(productId));
        }
    }
}
