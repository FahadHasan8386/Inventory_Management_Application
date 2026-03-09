using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrder>> GetPurchaseOrderAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId);
        Task<ResponseModel> AddPurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto);
        Task<ResponseModel> UpdatePurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto);
        Task<int> DeletePurchaseOrderAsync(long purchaseOrderId);
    }
}
