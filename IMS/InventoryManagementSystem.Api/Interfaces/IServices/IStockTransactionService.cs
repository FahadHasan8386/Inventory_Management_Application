using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IStockTransactionService
    {
        Task<List<StockTransaction>> GetStockTransactionAsync();
        Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId);
        Task<ResponseModel> AddStockTransactionAsync(StockTransactionDto stockTransactionDto);
        Task<ResponseModel> UpdateStockTransactionAsync(StockTransactionDto stockTransactionDto);
        Task<int> DeleteStockTransactionAsync(long stockTransactionIdproductId);
    }
}
