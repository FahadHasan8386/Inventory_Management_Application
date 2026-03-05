using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class SupplierDto : BaseModel
    {
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public string SupplierName { get; set; }

        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
