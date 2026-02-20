using Dapper;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<Product>> GetAllProductAsync()
        {
            var sql = @"SELECT * FROM  Products";
            _connection.Open();
            var result = await _connection.QueryAsync<Product>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            const string sql = @"SELECT TOP(1) * FROM Products WHERE ProductId = @productId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<Product>(sql, new
            {
                productId
            });
        }

        public async Task<int> DeleteProductAsync(long productId)
        {
            var sql = @"DELETE FROM Products WHERE ProductId = @productId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @ProductId = productId
            });
            _connection.Close();
            return result;
        }
    }
}
