using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;
using System.Transactions;

namespace InventoryManagementSystem.Api.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<List<PurchaseOrder>> GetPurchaseOrderAsync()
        {
            return await _purchaseOrderRepository.GetAllPurchaseOrderAsync();
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(long purchaseOrderId)
        {
            return await _purchaseOrderRepository.GetPurchaseOrderByIdAsync(purchaseOrderId);
        }

        public async Task<ResponseModel> AddPurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(purchaseOrderDto.PurchaseOrderName))
                //{
                //    return new ResponseModel
                //    {
                //        Code = StatusCodes.Status400BadRequest,
                //        Message = "Purchase Order Name is Required."
                //    };
                //}
                if (purchaseOrderDto.SupplierId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Supplier Id is required."
                    };
                }
                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _purchaseOrderRepository.AddPurchaseOrderAsync(purchaseOrderDto);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Purchase Order has been successfully created."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Purchase Order creation unsuccessful."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }


        public async Task<ResponseModel> UpdatePurchaseOrderAsync(PurchaseOrderDto purchaseOrderDto)
        {
            try
            {
                if (purchaseOrderDto.PurchaseOrderId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid Purchase Order ID."
                    };
                }
                //if (string.IsNullOrWhiteSpace(purchaseOrderDto.PurchaseOrderName))
                //{
                //    return new ResponseModel
                //    {
                //        Code = StatusCodes.Status400BadRequest,
                //        Message = "Purchase Order name is required."
                //    };
                //}
                if (purchaseOrderDto.SupplierId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Supplier Id is Required."
                    };
                }
                int result;

                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _purchaseOrderRepository.UpdatePurchaseOrderAsync(purchaseOrderDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Purchase Order updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Purchase Order not found."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }
        public async Task<int> DeletePurchaseOrderAsync(long purchaseOrderId)
        {
            return await _purchaseOrderRepository.DeletePurchaseOrderAsync(purchaseOrderId);
        }
    }
}
