using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _stockTransactionRepository;

        public StockTransactionService(IStockTransactionRepository stockTransactionRepository)
        {
            _stockTransactionRepository = stockTransactionRepository;
        }

        public async Task<List<StockTransaction>> GetStockTransactionAsync()
        {
            return await _stockTransactionRepository.GetAllStockTransactionAsync();
        }

        public async Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId)
        {
            return await _stockTransactionRepository.GetStockTransactionByIdAsync(stockTransactionId);
        }

        public async Task<int> DeleteStockTransactionAsync(long stockTransactionId)
        {
            return await _stockTransactionRepository.DeleteStockTransactionAsync(stockTransactionId);
        }
    }
}
