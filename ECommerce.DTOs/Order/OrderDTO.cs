using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Order
{
	public class OrderDTO
	{
        public int OrderId { get; set; }
        public string CustomerName { get; set; } // If using user table
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        // public string Items { get; set; }
        public List<OrderDetailDTO> OrderItems { get; set; }

    }
}