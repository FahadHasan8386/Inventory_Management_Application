using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ISalesOrderRepository
    {
        Task<List<SalesOrder>> GetAllSalesOrderAsync();
        Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId);
        Task<int> DeleteSalesOrderAsync(long salesOrderId);
    }
}
