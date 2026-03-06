using IMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.ViewModel
{
    public sealed class ProductViewModel : BaseModel
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public CategoryViewModel Category { get; set; } = new();

        public decimal UnitPrice { get; set; } = 0;

        public int StockQuantity { get; set; } = 0;
    }
}
