using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Category
{
	public class CategoryDTO
	{
        public int  CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}