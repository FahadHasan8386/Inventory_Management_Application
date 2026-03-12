using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IStockTransactionRepository
    {
        Task<List<StockTransaction>> GetAllStockTransactionAsync();
        Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId);
        Task<long> AddStockTransactionAsync(StockTransactionDto stockTransactionDto);
        Task<int> UpdateStockTransactionAsync(StockTransactionDto stockTransactionDto);
        Task<int> DeleteStockTransactionAsync(long stockTransactionId);
    }
}
