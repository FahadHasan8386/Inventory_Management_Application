using InventoryManagementSystem.Api.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionController : ControllerBase
    {
        public readonly IStockTransactionService _stockTransactionService;

        public StockTransactionController(IStockTransactionService stockTransactionService)
        {
            _stockTransactionService = stockTransactionService;
        }

        [HttpGet("GetAllStockTransaction")]
        public async Task<IActionResult> GetAllStockTransactionAsync()
        {
            return Ok(await _stockTransactionService.GetStockTransactionAsync());
        }

        [HttpGet("GetStockTransactionById/{stockTransactionId}")]
        public async Task<IActionResult> GetStockTransactionByIdAsync(long stockTransactionId)
        {
            return Ok(await _stockTransactionService.GetStockTransactionByIdAsync(stockTransactionId));
        }

        [HttpDelete("DeleteStockTransaction/{stockTransactionId}")]
        public async Task<IActionResult> DeleteStockTransactionAsync(long stockTransactionId)
        {
            if (stockTransactionId == 0)
                return BadRequest();

            return Ok(await _stockTransactionService.DeleteStockTransactionAsync(stockTransactionId));
        }
    
    }
}
