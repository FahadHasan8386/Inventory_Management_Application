using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            return Ok(await _customerService.GetCustomerAsync());
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(long customerId)
        {
            return Ok(await _customerService.GetCustomerByIdAsync(customerId));
        }

        [HttpDelete("DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync(long customerId)
        {
            if (customerId == 0)
                return BadRequest();

            return Ok(await _customerService.DeleteCustomerAsync(customerId));
        }
    }
}
 