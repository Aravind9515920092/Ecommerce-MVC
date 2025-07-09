using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Product
{
	public class ProductStockDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentStock { get; set; }
       
        public bool Newstock { get; set; }
    }
}