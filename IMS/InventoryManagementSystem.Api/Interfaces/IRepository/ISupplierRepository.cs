using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplierAsync();
        Task<Supplier?> GetSupplierByIdAsync(long supplierId);
        Task<int> DeleteSupplierAsync(long supplierId);
    }
}
