using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class ProductDto : BaseModel
    {
        public long ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; } = 0;

        public int StockQuantity { get; set; } = 0;
    }
}
