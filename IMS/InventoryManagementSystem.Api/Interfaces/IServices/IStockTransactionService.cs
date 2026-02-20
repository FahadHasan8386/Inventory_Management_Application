using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IStockTransactionService
    {
        Task<List<StockTransaction>> GetStockTransactionAsync();
        Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId);
        Task<int> DeleteStockTransactionAsync(long stockTransactionIdproductId);
    }
}
