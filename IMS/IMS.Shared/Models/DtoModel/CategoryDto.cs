using ExpenseManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Shared.Models.DtoModel
{
    public class CategoryDto : BaseModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string? CategoryDescription { get; set; }
    }  
}
