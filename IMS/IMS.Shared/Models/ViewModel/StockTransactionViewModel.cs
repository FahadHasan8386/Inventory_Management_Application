using IMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.ViewModel
{
    public sealed class StockTransactionViewModel : BaseModel
    {
        public long TransactionId { get; set; }

        public long ProductId { get; set; }

        public ProductViewModel Product { get; set; } = new();

        public string? TransactionType { get; set; } // IN / OUT

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string? ReferenceType { get; set; } // PO / SO

        public long? ReferenceId { get; set; }
    }
}
