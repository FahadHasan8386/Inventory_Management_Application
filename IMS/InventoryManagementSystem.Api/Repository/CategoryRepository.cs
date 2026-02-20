using Dapper;
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

        public async Task<int> DeleteCategoryAsync(long categoryId)
        {
            var sql = @"DELETE FROM Categories WHERE @CateoryId = @CateoryId";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                @CateoryId = categoryId
            });
            _connection.Close();
            return result;
        }

    }
}
