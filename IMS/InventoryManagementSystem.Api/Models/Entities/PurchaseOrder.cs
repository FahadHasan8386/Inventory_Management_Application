using ExpenseManagement.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class PurchaseOrder : BaseModel
    {
        public long PurchaseOrderId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalAmount { get; set; }

        [MaxLength(255)]
        public string? Remarks { get; set; }

        // Navigation
        public Supplier Supplier { get; set; }
    }
}
