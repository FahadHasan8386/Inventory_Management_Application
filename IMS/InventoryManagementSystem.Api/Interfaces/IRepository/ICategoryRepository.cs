using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(long categoryId);
        Task<long> AddCategoryAsync(CategoryDto categoryDto);
        Task<int> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<int> DeleteCategoryAsync(long categoryId);
    }
}
