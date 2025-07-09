using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Product
{
	public class ProductStockUpdateDTO
	{
        
            public int Id { get; set; }
         
            public int Quantity { get; set; }     // ✅ Required
           
        

    }
}