using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;
using System.Transactions;

namespace InventoryManagementSystem.Api.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _stockTransactionRepository;

        public StockTransactionService(IStockTransactionRepository stockTransactionRepository)
        {
            _stockTransactionRepository = stockTransactionRepository;
        }

        public async Task<List<StockTransaction>> GetStockTransactionAsync()
        {
            return await _stockTransactionRepository.GetAllStockTransactionAsync();
        }

        public async Task<StockTransaction?> GetStockTransactionByIdAsync(long stockTransactionId)
        {
            return await _stockTransactionRepository.GetStockTransactionByIdAsync(stockTransactionId);
        }

        public async Task<ResponseModel> AddStockTransactionAsync(StockTransactionDto stockTransactionDto)
        {
            try
            {
                if(stockTransactionDto.ProductId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Product Id is Required ."
                    };
                }
                if (stockTransactionDto.Quantity <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Quantity must be grater than zero."
                    };
                }
                if (string.IsNullOrWhiteSpace(stockTransactionDto.TransactionType))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Transaction Type is required."
                    };
                }
                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _stockTransactionRepository.AddStockTransactionAsync(stockTransactionDto);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Stock Transaction has been successfully created."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Stock Transaction creation failed."
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


        public async Task<ResponseModel> UpdateStockTransactionAsync(StockTransactionDto stockTransactionDto)
        {
            try
            {
                if (stockTransactionDto.TransactionId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid Transaction Id."
                    };
                }

                if (stockTransactionDto.ProductId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Product Id is required."
                    };
                }

                if (stockTransactionDto.Quantity <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Quantity must be greater than zero."
                    };
                }
                int result;

                using (TransactionScope transactionScope =
                       new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _stockTransactionRepository.UpdateStockTransactionAsync(stockTransactionDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Stock Transaction Created Successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Stock Transaction not found."
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

        public async Task<int> DeleteStockTransactionAsync(long stockTransactionId)
        {
            return await _stockTransactionRepository.DeleteStockTransactionAsync(stockTransactionId);
        }
    }
}
