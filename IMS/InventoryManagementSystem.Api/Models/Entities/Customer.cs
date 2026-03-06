using IMS.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public sealed class Customer : BaseModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string? ContactPerson { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public decimal TotalCreditLimit { get; set; } = 0;
    }
}
