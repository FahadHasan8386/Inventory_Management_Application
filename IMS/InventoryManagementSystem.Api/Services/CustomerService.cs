using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _customerRepository.GetAllCustomerAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<int> DeleteCustomerAsync(long customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }

    }
}
