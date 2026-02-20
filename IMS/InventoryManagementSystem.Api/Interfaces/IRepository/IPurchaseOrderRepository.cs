using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrder>> GetAllPurchaseOrderAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId);
        Task<int> DeletePurchaseOrderAsync(long purchaseOrderId);
    }
}
