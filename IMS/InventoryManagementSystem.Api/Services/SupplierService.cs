using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;
using System.Transactions;

namespace InventoryManagementSystem.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<Supplier>> GetSupplierAsync()
        {
            return await _supplierRepository.GetAllSupplierAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(long supplierId)
        {
            return await _supplierRepository.GetSupplierByIdAsync(supplierId);
        }

        public async Task<ResponseModel> AddSupplierAsync(SupplierDto supplierDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(supplierDto.SupplierName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Supplier Name is Required."
                    };
                }
                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _supplierRepository.AddSupplierAsync(supplierDto);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Supplier has been successfully created."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Supplier creation unsuccessful."
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


        public async Task<ResponseModel> UpdateSupplierAsync(SupplierDto supplierDto)
        {
            try
            {
                if (supplierDto.SupplierId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid Supplier ID."
                    };
                }

                if (string.IsNullOrWhiteSpace(supplierDto.SupplierName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Supplier name is required."
                    };
                }

                int result;

                using (TransactionScope transactionScope =
                       new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _supplierRepository.UpdateSupplierAsync(supplierDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Supplier updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Supplier not found."
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

        public async Task<ResponseModel> DeleteSupplierAsync(long supplierId)
        {
            try
            {
                if (supplierId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Required Supplier id."
                    };

                }
                int result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _supplierRepository.DeleteSupplierAsync(supplierId);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Supplier delete Sucessfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Supplier not found."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 500,
                    Message = ex.Message.ToString()
                };
            }
        }
    }
}
