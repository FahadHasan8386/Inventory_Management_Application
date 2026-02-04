using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class Product
    {
        public long ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; } = 0;

        public int StockQuantity { get; set; } = 0;

        public Category Category { get; set; }
    }
}
