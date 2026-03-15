using Dapper;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly IDbConnection _connection;

        public SalesOrderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<SalesOrder>> GetAllSalesOrderAsync()
        {
            var sql = @"SELECT p.SalesOrderId,
                               p.OrderDate,
                               p.TotalAmount,
                               p.InActive,
                               p.CreatedBy,
	                           p.CreatedAt,
	                           p.ModifiedBy,
	                           p.ModifiedAt,
                               p.CustomerId,
                               c.CustomerName
                               FROM SalesOrders AS p
                               INNER JOIN Customers AS c ON p.CustomerId = c.CustomerId";
            _connection.Open();
            var result = await _connection.QueryAsync(sql,
                map: (SalesOrder p, Customer c) =>
                {
                    p.Customer = c;
                    return p;
                },
                splitOn: "CustomerId");
            _connection.Close();

            return result.ToList();
        }

        public async Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId)
        {
            const string sql = @"SELECT p.SalesOrderId,
                               p.OrderDate,
                               p.TotalAmount,
                               p.InActive,
                               p.CreatedBy,
	                           p.CreatedAt,
	                           p.ModifiedBy,
	                           p.ModifiedAt,
                               p.CustomerId,
                               c.CustomerName
                        FROM SalesOrders AS p
                        INNER JOIN Customers AS c ON p.CustomerId = c.CustomerId
                        WHERE p.SalesOrderId = @SalesOrderId";

            using var connection = _connection;

            var result = await connection.QueryAsync<SalesOrder, Customer, SalesOrder>(
                sql,
                (p, c) =>
                {
                    p.Customer = c;
                    return p;
                },
                new { salesOrderId },
                splitOn: "CustomerId"
            );

            return result.FirstOrDefault();
        }

        public async Task<long> AddSalesOrderAsync(SalesOrderDto salesOrderDto)
        {
            var sql = @"INSERT INTO SalesOrders ( CustomerId, OrderDate, TotalAmount, CreatedBy)
                        OUTPUT INSERTED.SalesOrderId
                        VALUES (@CustomerId, @OrderDate, @TotalAmount, @CreatedBy)";
            _connection.Open();
            var reasult = await _connection.ExecuteScalarAsync<long>(sql, salesOrderDto);
            _connection.Close();
            return reasult;
        }

        public async Task<int> UpdateSalesOrderAsync(SalesOrderDto salesOrderDto)
        {
            var sql = @"UPDATE SalesOrders SET 
                        CustomerId = @CustomerId,
                        OrderDate = @OrderDate,
                        TotalAmount = @TotalAmount, 
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE SalesOrderId = @SalesOrderId";
            return await _connection.ExecuteAsync(sql, new
            {
                salesOrderDto.CustomerId,
                salesOrderDto.OrderDate,
                salesOrderDto.TotalAmount,
                ModifiedBy = salesOrderDto.CreatedBy,
                salesOrderDto.SalesOrderId
            });
        }

        public async Task<int> DeleteSalesOrderAsync(long salesOrderId)
        {
            var sql = @"DELETE FROM SalesOrders WHERE SalesOrderId = @salesOrderId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @SalesOrderId = salesOrderId
            });
            _connection.Close();
            return result;
        }
    }
}
