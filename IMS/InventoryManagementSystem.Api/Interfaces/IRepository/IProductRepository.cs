using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(long productId);
        Task<long> AddProductAsync(ProductDto productDto);
        Task<int> UpdateProductAsync(ProductDto productDto);
        Task<int> DeleteProductAsync(long productId);
    }
}
