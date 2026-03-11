using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;
using System.Transactions;

namespace InventoryManagementSystem.Api.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            return await _salesOrderRepository.GetAllSalesOrderAsync();
        }

        public async Task<SalesOrder?> GetSalesOrderByIdAsync(long salesOrderId)
        {
            return await _salesOrderRepository.GetSalesOrderByIdAsync(salesOrderId);
        }

        public async Task<ResponseModel> AddSalesOrderAsync(SalesOrderDto salesOrderDto)
        {
            try
            {
                if (salesOrderDto.CustomerId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Customer Id is required."
                    };
                }
                if (salesOrderDto.TotalAmount <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Total amount must be greater than zero."
                    };
                }
                if (salesOrderDto.OrderDate == default)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Order date is required."
                    };
                }
                if (salesOrderDto.OrderDate > DateTime.Now)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Order date cannot be in the future."
                    };
                }
                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _salesOrderRepository.AddSalesOrderAsync(salesOrderDto);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Sales Order has been successfully created."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Sales Order creation unsuccessful."
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


        public async Task<ResponseModel> UpdateSalesOrderAsync(SalesOrderDto salesOrderDto)
        {
            try
            {
                if (salesOrderDto.SalesOrderId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Sales  Order ID is Invalid."
                    };
                }
                if (salesOrderDto.CustomerId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Customer Id is Required."
                    };
                }
                if (salesOrderDto.OrderDate == default)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Order date is required."
                    };
                }
                if (salesOrderDto.OrderDate > DateTime.Now)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Order date cannot be in the future."
                    };
                }
                int result;
                using (TransactionScope transactionScope =
                       new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _salesOrderRepository.UpdateSalesOrderAsync(salesOrderDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Sales Order updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Sales Order not found."
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

        public async Task<int> DeleteSalesOrderAsync(long salesOrderId)
        {
            return await _salesOrderRepository.DeleteSalesOrderAsync(salesOrderId);
        }
    }
}
