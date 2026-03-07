using IMS.Shared.Models;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync();
        Task<Product?> GetProductByIdAsync(long productId);
        Task<ResponseModel> AddProductAsync(ProductDto productDto);
        Task<ResponseModel> UpdateProductAsync(ProductDto productDto);
        Task<int> DeleteProductAsync(long productId);
        
    }
}
