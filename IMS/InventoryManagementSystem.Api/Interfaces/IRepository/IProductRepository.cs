using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(long productId);
        Task<int> DeleteProductAsync(long productId);
    }
}
