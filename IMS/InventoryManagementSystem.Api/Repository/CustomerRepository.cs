using Dapper;
using IMS.Shared.Models.DtoModel;
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

        public async Task<long> AddCustomerAsync(CustomerDto customerDto)
        {
            var sql = @"INSERT INTO Customers (CustomerName , ContactPerson ,Phone ,Email ,Address ,TotalCreditLimit , CreatedBy)
                        OUTPUT INSERTED.CustomerId
                        VALUES(@CustomerName , @ContactPerson, @Phone, @Email ,@Address ,@TotalCreditLimit ,@CreatedBy)";
            _connection.Open();
            // Dapper auto maps DTO properties to SQL parameters
            var result = await _connection.ExecuteScalarAsync<long>(sql,customerDto);
            _connection.Close();
            return result;
        }

        public async Task<int> UpdateCustomerAsync(CustomerDto customerDto)
        {
            var sql = @"UPDATE Customers SET 
                        CustomerName = @CustomerName,
                        ContactPerson = @ContactPerson,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        TotalCreditLimit = @TotalCreditLimit,    
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE CustomerId = @CustomerId
                        ";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @CustomerId = customerDto.CustomerId,
                @CustomerName = customerDto.CustomerName,
                @ContactPerson = customerDto.ContactPerson,
                @Phone = customerDto.Phone,
                @Email = customerDto.Email,
                @Address = customerDto.Address,
                @TotalCreditLimit = customerDto.TotalCreditLimit,
                @ModifiedBy = customerDto.CreatedBy
            });
            _connection.Close();
            return result;
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
