using Dapper;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
              _connection = connection;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            var sql = @"SELECT * FROM  Customers";
            _connection.Open();
            var result = await _connection.QueryAsync<Customer>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        {
            const string sql = @"SELECT TOP(1) * FROM Customers WHERE CustomerId = @customerId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new
            {
                customerId
            });
        }

        public async Task<int> DeleteCustomerAsync(long customerId)
        {
            var sql = @"DELETE FROM Customers WHERE CustomerId = @customerId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @CustomerId = customerId
            });
            _connection.Close();
            return result;
        }
    }
}
