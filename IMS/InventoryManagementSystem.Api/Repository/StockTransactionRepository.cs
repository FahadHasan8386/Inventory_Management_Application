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
            var sql = @"SELECT 
                        p.TransactionId,
                        p.TransactionType,
                        p.Quantity,
                        p.TransactionDate,
                        p.ReferenceType,
                        p.ReferenceId,
                        p.CreatedBy,
                        p.CreatedAt,
                        p.ModifiedBy,
                        p.ModifiedAt,
                        p.ProductId,
                        c.ProductId,
                        c.ProductName
                        FROM StockTransactions AS p
                        INNER JOIN Products AS c 
                        ON p.ProductId = c.ProductId";

            _connection.Open();

            var result = await _connection.QueryAsync<StockTransaction, Product, StockTransaction>(
                sql,
                (p, c) =>
                {
                    p.Product = c;
                    return p;
                },
                splitOn: "ProductId"
            );

            _connection.Close();

            return result.ToList();
        }

        public async Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId)
        {
            var sql = @"SELECT 
                        p.TransactionId,
                        p.TransactionType,
                        p.Quantity,
                        p.TransactionDate,
                        p.ReferenceType,
                        p.ReferenceId,
                        p.CreatedBy,
                        p.CreatedAt,
                        p.ModifiedBy,
                        p.ModifiedAt,
                        p.ProductId,
                        c.ProductId,
                        c.ProductName
                        FROM StockTransactions AS p
                        INNER JOIN Products AS c 
                        ON p.ProductId = c.ProductId
                        WHERE p.TransactionId = @stockTransactionId";

            _connection.Open();

            var result = await _connection.QueryAsync<StockTransaction, Product, StockTransaction>(
                sql,
                (p, c) =>
                {
                    p.Product = c;
                    return p;
                },
                new { stockTransactionId },
                splitOn: "ProductId"
            );

            _connection.Close();

            return result.FirstOrDefault();
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
