using ExpenseManagement.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class SalesOrder : BaseModel
    {
        public long SalesOrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
    }
}
