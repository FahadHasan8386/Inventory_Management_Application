using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync();
        Task<Product?> GetProductByIdAsync(long productId);
        Task<int> DeleteProductAsync(long productId);
        
    }
}
