using IMS.Shared.Models;
using IMS.Shared.Models.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public sealed class PurchaseOrder : BaseModel
    {
        public long PurchaseOrderId { get; set; }

        public int SupplierId { get; set; }

        public SupplierViewModel Supplier { get; set; } = new();

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public decimal TotalAmount { get; set; }

        public string? Remarks { get; set; }
    }
}
