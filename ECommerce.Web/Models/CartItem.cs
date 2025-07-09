﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
	public class CartItem
	{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total => Price * Quantity;

        public string ProductName { get; internal set; }
    }
}