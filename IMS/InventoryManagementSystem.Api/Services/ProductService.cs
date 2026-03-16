using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;
using System.Transactions;

namespace InventoryManagementSystem.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _productRepository.GetAllProductAsync();
        }

        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<ResponseModel> AddProductAsync(ProductDto productDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productDto.ProductName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Product Name is Required."
                    };
                }
                if (productDto.CategoryId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Category Id is required."
                    };
                }
                long result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _productRepository.AddProductAsync(productDto);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Product has been successfully created."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Product creation unsuccessful."
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


        public async Task<ResponseModel> UpdateProductAsync(ProductDto productDto)
        {
            try
            {
                if (productDto.ProductId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Invalid Product ID."
                    };
                }
                if (string.IsNullOrWhiteSpace(productDto.ProductName))
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Product name is required."
                    };
                }
                if (productDto.CategoryId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = 400,
                        Message = "Category Id is Required."
                    };
                }
                int result;

                using (TransactionScope transactionScope =
                       new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _productRepository.UpdateProductAsync(productDto);
                    transactionScope.Complete();
                }

                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Product updated successfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Product not found."
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

        public async Task<ResponseModel> DeleteProductAsync(long productId)
        {
            try
            {
                if (productId <= 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Required Product id."
                    };

                }
                int result;
                using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _productRepository.DeleteProductAsync(productId);
                    transactionScope.Complete();
                }
                if (result > 0)
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status200OK,
                        Message = "Product deleted Sucessfully."
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = "Product not found."
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
