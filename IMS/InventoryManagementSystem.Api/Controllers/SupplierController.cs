using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Services;
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

        [HttpPost("CreateSupplier")]
        public async Task<IActionResult> CreateSupplierAsync([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest();
            }
            return Ok(await _supplierService.AddSupplierAsync(supplierDto));
        }

        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplierAsync([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest();
            }
            return Ok(await _supplierService.UpdateSupplierAsync(supplierDto));
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
