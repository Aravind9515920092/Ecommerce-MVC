using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Product
{
	public class ProductDTO
	{
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // From Join
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }

        public string ImageUrl {  get; set; } 
    }
}