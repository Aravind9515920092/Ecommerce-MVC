using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models.Entities
{
	public class Order
	{
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // Pending, Shipped, Delivered, Cancelled
       
        public int UserId { get; set; }
        public virtual User User { get; set; }

      
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}