using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class CustomerDto : BaseModel
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(150)]
        public string CustomerName { get; set; }

        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? Address { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalCreditLimit { get; set; } = 0;
    }
}
