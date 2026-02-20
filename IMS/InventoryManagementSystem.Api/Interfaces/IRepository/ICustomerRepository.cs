using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(long customerId);
        Task<int> DeleteCustomerAsync(long customerId);
    }
}
