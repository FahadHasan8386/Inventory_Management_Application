using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class SalesOrderDto : BaseModel
    {
        public long SalesOrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalAmount { get; set; }
    }
}
