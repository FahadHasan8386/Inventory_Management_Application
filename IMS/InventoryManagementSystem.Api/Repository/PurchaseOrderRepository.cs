using Dapper;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly IDbConnection _connection;

        public PurchaseOrderRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<PurchaseOrder>> GetAllPurchaseOrderAsync()
        {
            var sql = @"SELECT * FROM  PurchaseOrders";
            _connection.Open();
            var result = await _connection.QueryAsync<PurchaseOrder>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId)
        {
            const string sql = @"SELECT TOP(1) * FROM PurchaseOrders WHERE PurchaseOrderId = @purchaseOrderId";

            using var connection = _connection;
            return await _connection.QueryFirstOrDefaultAsync<PurchaseOrder>(sql, new
            {
                purchaseOrderId
            });
        }

        public async Task<long> AddPurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto)
        {
            var sql = @"INSERT INTO PurchaseOrders (PurchaseOrderName, SupplierId, OrderDate, TotalAmount, Remarks, CreatedBy)
                        OUTPUT INSERTED.PurchaseOrderId
                        VALUES (@PurchaseOrderName, @SupplierId, @OrderDate, @TotalAmount, @Remarks, @CreatedBy)";
            _connection.Open();
            var reasult = await _connection.ExecuteScalarAsync<long>(sql, purchaseOrderDto);
            _connection.Close();
            return reasult;
        }

        public async Task<int> UpdatePurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto)
        {
            var sql = @"UPDATE PurchaseOrders SET 
                        SupplierId = @SupplierId,
                        OrderDate = @OrderDate,
                        TotalAmount = @TotalAmount, 
                        Remarks = @Remarks, 
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE PurchaseOrderId = @PurchaseOrderId";
            return await _connection.ExecuteAsync(sql, new
            {
                purchaseOrderDto.SupplierId,
                purchaseOrderDto.OrderDate,
                purchaseOrderDto.TotalAmount,
                purchaseOrderDto.Remarks,
                ModifiedBy = purchaseOrderDto.CreatedBy,
                purchaseOrderDto.PurchaseOrderId
            });
        }

        public async Task<int> DeletePurchaseOrderAsync(long purchaseOrderId)
        {
            var sql = @"DELETE FROM PurchaseOrders WHERE PurchaseOrderId = @purchaseOrderId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @PurchaseOrderId = purchaseOrderId
            });
            _connection.Close();
            return result;
        }
    }
}
