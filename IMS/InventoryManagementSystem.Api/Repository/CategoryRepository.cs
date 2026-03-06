using Dapper;
using IMS.Shared.Models.DtoModel;
using InventoryManagementSystem.Api.Interfaces.IRepository;
using InventoryManagementSystem.Api.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace InventoryManagementSystem.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;

        public CategoryRepository(IDbConnection connection) 
        {
            _connection = connection;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var sql = @"SELECT * FROM  Categories";
            _connection.Open();
            var result = await _connection.QueryAsync<Category>(sql);
            _connection.Close();
            return result.ToList();
        }

        public async Task<Category?> GetCategoryByIdAsync(long categoryId)
        {
            const string sql = @"SELECT TOP(1) * FROM Categories WHERE CategoryId = @categoryId";
            
            using var connection = _connection; 
            return await _connection.QueryFirstOrDefaultAsync<Category>(sql, new
            {
                categoryId
            });
        }

        public async Task<long> AddCategoryAsync(CategoryDto categoryDto)
        {
            var sql = @"INSERT INTO Categories (CategoryName , CategoryDescription , CreatedBy)
                        OUTPUT INSERTED.CategoryId
                        VALUES(@CategoryName , @CategoryDescription ,@CreatedBy)";
            _connection.Open();
            var result = await _connection.ExecuteScalarAsync<long>(sql, new
            {
                @CategoryName = categoryDto.CategoryName,
                @CategoryDescription = categoryDto.CategoryDescription,
                @CreatedBy = categoryDto.CreatedBy
            });
            _connection.Close();
            return result;
        }

        public async Task<int> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var sql = @"UPDATE Categories SET 
                        CategoryName = @CategoryName,
                        CategoryDescription = @CategoryDescription,
                        ModifiedBy = @ModifiedBy,
                         ModifiedAt = GETDATE()
                        WHERE CategoryId = @CategoryId
                        ";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @CategoryId = categoryDto.CategoryId,
                @CategoryName = categoryDto.CategoryName,
                @CategoryDescription = categoryDto.CategoryDescription,
                @ModifiedBy = categoryDto.CreatedBy
            });
            _connection.Close();
            return result;
        }

        public async Task<int> DeleteCategoryAsync(long categoryId)
        {
            var sql = @"DELETE FROM Categories WHERE CategoryId = @CategoryId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @CategoryId = categoryId
            });
            _connection.Close();
            return result;
        }

    }
}
