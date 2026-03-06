using IMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMS.Shared.Models.ViewModel
{
    public sealed class SalesOrderViewModel : BaseModel
    {
        public long SalesOrderId { get; set; }

        public int CustomerId { get; set; }

        public CustomerViewModel Customer { get; set; } = new();

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public decimal TotalAmount { get; set; }
    }
}
