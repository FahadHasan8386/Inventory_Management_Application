using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IStockTransactionRepository
    {
        Task<List<StockTransaction>> GetAllStockTransactionAsync();
        Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId);
        Task<int> DeleteStockTransactionAsync(long stockTransactionId);
    }
}
