using Dapper;
using IMS.Shared.Models.DtoModel;
using IMS.Shared.Models.ViewModel;
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
            var sql = @"SELECT p.ProductId,
                               p.ProductName,
                               p.UnitPrice,
                               p.StockQuantity,
                               p.CreatedBy,
	                           p.CreatedAt,
	                           p.ModifiedBy,
	                           p.ModifiedAt,
                               p.CategoryId,
                               c.CategoryName
                               FROM Products AS p
                               INNER JOIN Categories AS c ON p.CategoryId = c.CategoryId";
            _connection.Open();
            var result = await _connection.QueryAsync(sql,
                map: (Product p, Category c) =>
                {
                    p.Category = c;
                    return p;
                },
                splitOn: "CategoryId");
            _connection.Close();

            return result.ToList();
        }

        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            const string sql = @"SELECT p.ProductId,
                               p.ProductName,
                               p.UnitPrice,
                               p.StockQuantity,
                               p.CreatedAt,
                               p.CategoryId,
                               c.CategoryName
                        FROM Products AS p
                        INNER JOIN Categories AS c ON p.CategoryId = c.CategoryId
                        WHERE p.ProductId = @ProductId";

            using var connection = _connection;

            var result = await connection.QueryAsync<Product, Category, Product>(
                sql,
                (p, c) =>
                {
                    p.Category = c;
                    return p;
                },
                new { ProductId = productId },
                splitOn: "CategoryId"
            );

            return result.FirstOrDefault();
        }

        public async Task<long> AddProductAsync(ProductDto productDto)
        {
            var sql = @"INSERT INTO Products(ProductName , CategoryId , UnitPrice , StockQuantity , CreatedBy)
                       OUTPUT INSERTED.ProductId
                       VALUES(@ProductName ,@CategoryId ,@UnitPrice, @StockQuantity ,@CreatedBy)";
            _connection.Open();
            var reasult = await _connection.ExecuteScalarAsync<long>(sql, productDto);
            _connection.Close();
            return reasult;
        }

        public async Task<int> UpdateProductAsync(ProductDto productDto)
        {
            var sql = @"UPDATE Products SET 
                        ProductName = @ProductName,
                        CategoryId = @CategoryId,
                        UnitPrice = @UnitPrice,
                        StockQuantity = @StockQuantity, 
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE ProductId = @ProductId
                        ";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @ProductId = productDto.ProductId,
                @ProductName = productDto.ProductName,
                @CategoryId = productDto.CategoryId,
                @UnitPrice = productDto.UnitPrice,
                @StockQuantity = productDto.StockQuantity,
                @ModifiedBy = productDto.CreatedBy
            });
            _connection.Close();
            return result;
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
