using Dapper;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private readonly IDbConnection _connection;

        public StockTransactionRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<StockTransaction>> GetAllStockTransactionAsync()
        {
            var sql = @"SELECT * FROM  StockTransactions";
            _connection.Open();
            var result = await _connection.QueryAsync<StockTransaction>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId)
        {
            const string sql = @"SELECT TOP(1) * FROM StockTransactions WHERE StockTransactionId = @stockTransactionId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<StockTransaction>(sql, new
            {
                stockTransactionId
            });
        }

        public async Task<int> DeleteStockTransactionAsync(long transactionId)
        {
            var sql = @"DELETE FROM StockTransactions WHERE TransactionId = @transactionId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @TransactionId = transactionId
            });
            _connection.Close();
            return result;
        }
    }
}
