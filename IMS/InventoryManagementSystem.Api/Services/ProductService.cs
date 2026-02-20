using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;
using InventoryManagementSystem.Api.Repository;

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

        public async Task<int> DeleteProductAsync(long productId)
        {
            return await _productRepository.DeleteProductAsync(productId);
        }
    }
}
