using IMS.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Api.Models.Entities
{
    public class Supplier : BaseModel
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string? ContactPerson { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

    }
}
