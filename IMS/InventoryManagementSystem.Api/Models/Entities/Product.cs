using IMS.Shared.Models;
using IMS.Shared.Models.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public sealed class Product : BaseModel    
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = new();

        public decimal UnitPrice { get; set; } = 0;

        public int StockQuantity { get; set; } = 0;
    }
}
