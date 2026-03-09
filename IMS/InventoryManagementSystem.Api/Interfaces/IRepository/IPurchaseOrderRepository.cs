using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrder>> GetAllPurchaseOrderAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId);
        Task<long> AddPurchaseOrderAsync(PurchaseOrderDto PurchaseOrderDto);
        Task<int> UpdatePurchaseOrderAsync(PurchaseOrderDto PurchaseOrderDto);
        Task<int> DeletePurchaseOrderAsync(long purchaseOrderId);
    }
}
