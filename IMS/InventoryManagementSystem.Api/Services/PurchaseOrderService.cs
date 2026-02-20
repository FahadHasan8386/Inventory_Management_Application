using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;

namespace InventoryManagementSystem.Api.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<List<PurchaseOrder>> GetPurchaseOrderAsync()
        {
            return await _purchaseOrderRepository.GetAllPurchaseOrderAsync();
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId)
        {
            return await _purchaseOrderRepository.GetPurchaseOrderByIdAsync(purchaseOrderId);
        }

        public async Task<int> DeletePurchaseOrderAsync(long purchaseOrderId)
        {
            return await _purchaseOrderRepository.DeletePurchaseOrderAsync(purchaseOrderId);
        }
    }
}
