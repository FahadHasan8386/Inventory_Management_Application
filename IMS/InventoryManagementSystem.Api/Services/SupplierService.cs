using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;

namespace InventoryManagementSystem.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<Supplier>> GetSupplierAsync()
        {
            return await _supplierRepository.GetAllSupplierAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(long supplierId)
        {
            return await _supplierRepository.GetSupplierByIdAsync(supplierId);
        }

        public async Task<int> DeleteSupplierAsync(long supplierId)
        {
            return await _supplierRepository.DeleteSupplierAsync(supplierId);
        }
    }
}
