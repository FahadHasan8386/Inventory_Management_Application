using InventoryManagementSystem.Api.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        public readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplierAsync()
        {
            return Ok(await _supplierService.GetSupplierAsync());
        }

        [HttpGet("GetSupplierById/{supplierId}")]
        public async Task<IActionResult> GetSupplierByIdAsync(long supplierId)
        {
            return Ok(await _supplierService.GetSupplierByIdAsync(supplierId));
        }

        [HttpDelete("DeleteSupplier/{supplierId}")]
        public async Task<IActionResult> DeleteSupplierAsync(long supplierId)
        {
            if (supplierId == 0)
                return BadRequest();

            return Ok(await _supplierService.DeleteSupplierAsync(supplierId));
        }
    }
}
