using Dapper;
using IMS.Shared.Models.DtoModel;
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

        public async Task<long> AddStockTransactionAsync(StockTransactionDto stockTransactionDto)
        {
            var sql = @"INSERT INTO StockTransactions
               (ProductId, TransactionType, Quantity, TransactionDate, ReferenceType, ReferenceId, CreatedBy)
               OUTPUT INSERTED.TransactionId
               VALUES
               (@ProductId, @TransactionType, @Quantity, @TransactionDate, @ReferenceType, @ReferenceId, @CreatedBy)";

            _connection.Open();

            var result = await _connection.ExecuteScalarAsync<long>(sql, stockTransactionDto);

            _connection.Close();

            return result;
        }

        public async Task<int> UpdateStockTransactionAsync(StockTransactionDto stockTransactionDto)
        {
            var sql = @"UPDATE StockTransactions SET 
                ProductId = @ProductId,
                TransactionType = @TransactionType,
                Quantity = @Quantity,
                TransactionDate = @TransactionDate,
                ReferenceType = @ReferenceType,
                ReferenceId = @ReferenceId,
                ModifiedBy = @ModifiedBy,
                ModifiedAt = GETDATE()
                WHERE TransactionId = @TransactionId";

            _connection.Open();

            var result = await _connection.ExecuteAsync(sql, new
            {
                TransactionId = stockTransactionDto.TransactionId,
                ProductId = stockTransactionDto.ProductId,
                TransactionType = stockTransactionDto.TransactionType,
                Quantity = stockTransactionDto.Quantity,
                TransactionDate = stockTransactionDto.TransactionDate,
                ReferenceType = stockTransactionDto.ReferenceType,
                ReferenceId = stockTransactionDto.ReferenceId,
                ModifiedBy = stockTransactionDto.CreatedBy
            });

            _connection.Close();

            return result;
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
