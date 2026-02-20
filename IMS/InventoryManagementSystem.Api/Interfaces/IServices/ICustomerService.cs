using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(long customerId);
        Task<int> DeleteCustomerAsync(long customerId);
    }
}
