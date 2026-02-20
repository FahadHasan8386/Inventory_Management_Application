using Dapper;
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
