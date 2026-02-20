using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetSupplierAsync();
        Task<Supplier?> GetSupplierByIdAsync(long supplierId);
        Task<int> DeleteSupplierAsync(long supplierId);
    }
}
