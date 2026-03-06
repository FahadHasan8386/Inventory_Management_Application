using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplierAsync();
        Task<Supplier?> GetSupplierByIdAsync(long supplierId);
        Task<long> AddSupplierAsync(SupplierDto supplierDto);
        Task<int> UpdateSupplierAsync(SupplierDto supplierDto);
        Task<int> DeleteSupplierAsync(long supplierId);
    }
}
