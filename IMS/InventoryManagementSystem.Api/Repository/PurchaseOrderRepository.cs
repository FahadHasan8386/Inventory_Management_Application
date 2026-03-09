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
            var sql = @"SELECT p.PurchaseOrderId,
                               p.OrderDate,
                               p.TotalAmount,
                               p.Remarks,
                               p.CreatedBy,
	                           p.CreatedAt,
	                           p.ModifiedBy,
	                           p.ModifiedAt,
                               p.SupplierId,
                               c.SupplierName
                               FROM PurchaseOrders AS p
                               INNER JOIN Suppliers AS c ON p.SupplierId = c.SupplierId";
            _connection.Open();
            var result = await _connection.QueryAsync(sql,
                map: (PurchaseOrder p, Supplier c) =>
                {
                    p.Supplier = c;
                    return p;
                },
                splitOn: "SupplierId");
            _connection.Close();

            return result.ToList();
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long productId)
        {
            const string sql = @"SELECT p.PurchaseOrderId,
                               p.OrderDate,
                               p.TotalAmount,
                               p.Remarks,
                               p.CreatedAt,
                               p.SupplierId,
                               c.SupplierName
                        FROM PurchaseOrders AS p
                        INNER JOIN Suppliers AS c ON p.SupplierId = c.SupplierId
                        WHERE p.PurchaseOrderId = @PurchaseOrderId";

            using var connection = _connection;

            var result = await connection.QueryAsync<PurchaseOrder, Supplier, PurchaseOrder>(
                sql,
                (p, c) =>
                {
                    p.Supplier = c;
                    return p;
                },
                new { ProductId = productId },
                splitOn: "SupplierId"
            );

            return result.FirstOrDefault();
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
