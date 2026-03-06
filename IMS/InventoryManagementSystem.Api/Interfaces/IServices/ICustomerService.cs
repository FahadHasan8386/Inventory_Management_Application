using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(long customerId);
        Task<ResponseModel> AddCustomerAsync(CustomerDto customerDto);
        Task<ResponseModel> UpdateCustomerAsync(CustomerDto customerDto);
        Task<ResponseModel> DeleteCustomerAsync(long customerId);
    }
}
