using IMS.Shared.Models;
using IMS.Shared.Models.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public sealed class SalesOrder : BaseModel
    {
        public long SalesOrderId { get; set; }

        public int CustomerId { get; set; }

        public CustomerViewModel Customer { get; set; } = new();

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public decimal TotalAmount { get; set; }
    }
}
