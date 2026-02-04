using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public string SupplierName { get; set; }

        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
