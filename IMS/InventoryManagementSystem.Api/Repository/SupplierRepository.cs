using Dapper;
using IMS.Shared.Models.DtoModel;
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

        public async Task<long> AddSupplierAsync(SupplierDto supplierDto)
        {
            var sql = @"INSERT INTO Suppliers (SupplierName , ContactPerson ,Phone ,Email ,Address , CreatedBy)
                        OUTPUT INSERTED.SupplierId
                        VALUES(@SupplierName , @ContactPerson, @Phone, @Email ,@Address ,@CreatedBy)";
            _connection.Open();
            var result = await _connection.ExecuteScalarAsync<long>(sql, new
            {
                @SupplierName = supplierDto.SupplierName,
                @ContactPerson = supplierDto.ContactPerson,
                @Phone = supplierDto.Phone,
                @Email = supplierDto.Email,
                @Address = supplierDto.Address,
                @CreatedBy = supplierDto.CreatedBy
            });
            _connection.Close();
            return result;
        }

        public async Task<int> UpdateSupplierAsync(SupplierDto supplierDto)
        {
            var sql = @"UPDATE Suppliers SET 
                        SupplierName = @SupplierName,
                        ContactPerson = @ContactPerson,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE SupplierId = @SupplierId
                        ";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @SupplierId = supplierDto.SupplierId,
                @SupplierName = supplierDto.SupplierName,
                @ContactPerson = supplierDto.ContactPerson,
                @Phone = supplierDto.Phone,
                @Email = supplierDto.Email,
                @Address = supplierDto.Address,
                @ModifiedBy = supplierDto.CreatedBy
            });
            _connection.Close();
            return result;
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
