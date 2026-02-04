using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class StockTransaction
    {
        public long TransactionId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TransactionType { get; set; } // IN / OUT

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string? ReferenceType { get; set; } // PO / SO

        public long? ReferenceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        // Navigation
        public Product Product { get; set; }
    }
}
