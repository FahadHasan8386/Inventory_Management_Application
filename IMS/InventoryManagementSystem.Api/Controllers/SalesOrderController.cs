using InventoryManagementSystem.Api.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        public readonly ISalesOrderService _salesOrderService;

        public SalesOrderController(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        [HttpGet("GetAllSalesOrder")]
        public async Task<IActionResult> GetAllSalesOrderAsync()
        {
            return Ok(await _salesOrderService.GetSalesOrderAsync());
        }

        [HttpGet("GetSalesOrderById/{salesOrderId}")]
        public async Task<IActionResult> GetSalesOrderByIdAsync(long salesOrderId)
        {
            return Ok(await _salesOrderService.GetSalesOrderByIdAsync(salesOrderId));
        }

        [HttpDelete("DeleteSalesOrder/{salesOrderId}")]
        public async Task<IActionResult> DeleteSalesOrderAsync(long salesOrderId)
        {
            if (salesOrderId == 0)
                return BadRequest();

            return Ok(await _salesOrderService.DeleteSalesOrderAsync(salesOrderId));
        }
    }
}
