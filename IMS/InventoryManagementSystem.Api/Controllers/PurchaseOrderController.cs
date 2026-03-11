using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        public readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet("GetAllPurchaseOrder")]
        public async Task<IActionResult> GetAllPurchaseOrderAsync()
        {
            return Ok(await _purchaseOrderService.GetPurchaseOrderAsync());
        }

        [HttpGet("GetPurchaseOrderById/{productId}")]
        public async Task<IActionResult> GetPurchaseOrderByIdAsync(long purchaseOrderId)
        {
            return Ok(await _purchaseOrderService.GetPurchaseOrderByIdAsync(purchaseOrderId));
        }

        [HttpPost("CreatePurchaseOrder")]
        public async Task<IActionResult> CreatePurchaseOrderAsync([FromBody] PurchaseOrderDto purchaseOrderDto)
        {
            if (purchaseOrderDto == null)
            {
                return BadRequest();
            }
            return Ok(await _purchaseOrderService.AddPurchaseOrderAsync(purchaseOrderDto));
        }

        [HttpPut("UpdatePurchaseOrder")]
        public async Task<IActionResult> UpdatePurchaseOrderAsync([FromBody] PurchaseOrderDto purchaseOrderDto)
        {
            if (purchaseOrderDto == null)
            {
                return BadRequest();
            }
            return Ok(await _purchaseOrderService.UpdatePurchaseOrderAsync(purchaseOrderDto));
        }

        [HttpDelete("DeletePurchaseOrder/{purchaseOrderId}")]
        public async Task<IActionResult> DeletePurchaseOrderAsync(long purchaseOrderId)
        {
            if (purchaseOrderId == 0)
                return BadRequest();

            return Ok(await _purchaseOrderService.DeletePurchaseOrderAsync(purchaseOrderId));
        }
    }
}
