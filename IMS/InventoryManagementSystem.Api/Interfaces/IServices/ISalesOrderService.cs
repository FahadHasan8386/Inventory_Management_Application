using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ISalesOrderService
    {
        Task<List<SalesOrder>> GetSalesOrderAsync();
        Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId);
        Task<int> DeleteSalesOrderAsync(long salesOrderId);
    }
}
