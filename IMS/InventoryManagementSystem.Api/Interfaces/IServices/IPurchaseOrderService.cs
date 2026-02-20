using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrder>> GetPurchaseOrderAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId);
        Task<int> DeletePurchaseOrderAsync(long purchaseOrderId);
    }
}
