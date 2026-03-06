using IMS.Shared.Models.DtoModel;
using IMS.Shared.Models;
using InventoryManagementSystem.Api.Models.Entities;

namespace InventoryManagementSystem.Api.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(long categoryId);
        Task<ResponseModel> AddCategoryAsync(CategoryDto categoryDto);
        Task<ResponseModel> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<ResponseModel> DeleteCategoryAsync(long categoryId);
    }
}
