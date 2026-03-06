using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetSupplierAsync();
        Task<Supplier?> GetSupplierByIdAsync(long supplierId);
        Task<ResponseModel> AddSupplierAsync(SupplierDto supplierDto);
        Task<ResponseModel> UpdateSupplierAsync(SupplierDto supplierDto);
        Task<ResponseModel> DeleteSupplierAsync(long supplierId);
    }
}
