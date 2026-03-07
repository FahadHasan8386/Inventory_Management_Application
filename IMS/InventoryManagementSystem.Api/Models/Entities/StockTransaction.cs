using IMS.Shared.Models;
using IMS.Shared.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public sealed class StockTransaction : BaseModel
    {
        public long TransactionId { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; } = new();

        public string? TransactionType { get; set; } // IN / OUT

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string? ReferenceType { get; set; } // PO / SO

        public long? ReferenceId { get; set; }
    }
}
