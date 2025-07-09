using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Checkout
{
	public class PaymentDTO
	{
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }


    }
}