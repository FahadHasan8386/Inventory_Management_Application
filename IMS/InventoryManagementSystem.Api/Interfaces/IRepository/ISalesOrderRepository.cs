using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ISalesOrderRepository
    {
        Task<List<SalesOrder>> GetAllSalesOrderAsync();
        Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId);
        Task<long> AddSalesOrderAsync(SalesOrderDto salesOrderDto);
        Task<int> UpdateSalesOrderAsync(SalesOrderDto salesOrderDto);
        Task<int> DeleteSalesOrderAsync(long salesOrderId);
    }
}
