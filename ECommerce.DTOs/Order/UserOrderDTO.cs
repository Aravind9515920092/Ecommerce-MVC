using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Order
{
	public class UserOrderDTO
	{
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<UserOrderItemDTO> Items { get; set; }
    }
}