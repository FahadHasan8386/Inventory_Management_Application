using IMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMS.Shared.Models.ViewModel
{
    public sealed class PurchaseOrderViewModel : BaseModel
    {
        public long PurchaseOrderId { get; set; }
        
        public int SupplierId { get; set; }

        public SupplierViewModel Supplier { get; set; } = new();

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public decimal TotalAmount { get; set; }

        public string? Remarks { get; set; }
    }
}
