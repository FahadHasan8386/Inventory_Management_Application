using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplierAsync();
        Task<Supplier?> GetSupplierByIdAsync(long supplierId);
        Task<long> AddSupplierAsync(SupplierDto supplierId);
        Task<int> UpdateSupplierAsync(SupplierDto supplierId);
        Task<int> DeleteSupplierAsync(long supplierId);
    }
}
