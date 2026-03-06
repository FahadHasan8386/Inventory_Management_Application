using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(long customerId);
        Task<long> AddCustomerAsync(CustomerDto customerDto);
        Task<int> UpdateCustomerAsync(CustomerDto customerDto);
        Task<int> DeleteCustomerAsync(long customerId);
    }
}
