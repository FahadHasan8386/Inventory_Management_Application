using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ISalesOrderService
    {
        Task<List<SalesOrder>> GetSalesOrderAsync();
        Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId);
        Task<ResponseModel> AddSalesOrderAsync(SalesOrderDto salesOrderDto);
        Task<ResponseModel> UpdateSalesOrderAsync(SalesOrderDto salesOrderDto);
        Task<int> DeleteSalesOrderAsync(long salesOrderId);
    }
}
