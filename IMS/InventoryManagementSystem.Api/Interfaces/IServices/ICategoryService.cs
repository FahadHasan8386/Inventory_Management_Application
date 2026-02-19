using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(long categoryId);
        Task<int> DeleteCategoryAsync(long categoryId);
    }
}
