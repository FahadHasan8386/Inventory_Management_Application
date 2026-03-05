using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class StockTransactionDto : BaseModel
    {
        public long TransactionId { get; set; }

        public long ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string? TransactionType { get; set; } // IN / OUT

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string? ReferenceType { get; set; } // PO / SO

        public long? ReferenceId { get; set; }
    }
}
