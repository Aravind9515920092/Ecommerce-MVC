using ECommerce.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Order
{
	public class OrderCreateDTO
	{
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public int UserId { get; set; }
        public List<CartItemDTO> Items { get; set; }
        public string Status { get; set; }
    }
}