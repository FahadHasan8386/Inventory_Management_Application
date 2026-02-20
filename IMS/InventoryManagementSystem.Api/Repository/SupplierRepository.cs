using Dapper;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class SupplierRepository : ISupplierRepository

    {
        private readonly IDbConnection _connection;

        public SupplierRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<Supplier>> GetAllSupplierAsync()
        {
            var sql = @"SELECT * FROM  Suppliers";
            _connection.Open();
            var result = await _connection.QueryAsync<Supplier>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(long supplierId)
        {
            const string sql = @"SELECT TOP(1) * FROM Suppliers WHERE SupplierId = @supplierId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<Supplier>(sql, new
            {
                supplierId
            });
        }

        public async Task<int> DeleteSupplierAsync(long supplierId)
        {
            var sql = @"DELETE FROM Suppliers WHERE SupplierId = @supplierId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @SupplierId = supplierId
            });
            _connection.Close();
            return result;
        }
    }
}
