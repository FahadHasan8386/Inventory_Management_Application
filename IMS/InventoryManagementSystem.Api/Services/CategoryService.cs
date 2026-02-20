using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Interfaces.IServices;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(long categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }
        public async Task<int> DeleteCategoryAsync(long categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
