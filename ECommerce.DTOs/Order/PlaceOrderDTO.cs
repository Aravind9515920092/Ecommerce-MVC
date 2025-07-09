using ECommerce.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Order
{
    public class PlaceOrderDTO
    {
        public List<CartItemDTO> CartItems { get; set; }
        public decimal TotalAmount { get; set; }

        // Order Form Fields
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string PaymentMethod { get; set; }
    }
}