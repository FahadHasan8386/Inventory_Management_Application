using ExpenseManagement.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class Category : BaseModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string? CategoryDescription { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
 