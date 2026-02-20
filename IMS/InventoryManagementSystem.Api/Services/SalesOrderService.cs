using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            return await _salesOrderRepository.GetAllSalesOrderAsync();
        }

        public async Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId)
        {
            return await _salesOrderRepository.GetSalesOrderByIdAsync(salesOrderId);
        }

        public async Task<int> DeleteSalesOrderAsync(long salesOrderId)
        {
            return await _salesOrderRepository.DeleteSalesOrderAsync(salesOrderId);
        }
    }
}
