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
            var sql = @"SELECT * FROM  SalesOrders";
            _connection.Open();
            var result = await _connection.QueryAsync<SalesOrder>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId)
        {
            const string sql = @"SELECT TOP(1) * FROM SalesOrders WHERE SalesOrderId = @salesOrderId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<SalesOrder>(sql, new
            {
                salesOrderId
            });
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
